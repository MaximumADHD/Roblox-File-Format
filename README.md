# Roblox-File-Format
A C# library designed to make it easy to create and manipulate files in Roblox's model/place file format!

# Usage
The `RobloxFile` class is the main entry point for opening and saving files.
You can provide one of three possible inputs to `RobloxFile.Open`:

- A `string` containing the path to some `*.rbxl/.rbxlx` or `*.rbxm/*.rbxmx` to read from.
- A `Stream` or `byte[]` to be read from directly.

```cs
RobloxFile file = RobloxFile.Open(@"A:\Path\To\Some\File.rbxm");

// Make some changes...

file.Save(@"A:\Path\To\Some\NewFile.rbxm");
```

Depending on the format being used by the file, it will return either a `BinaryRobloxFile` or an `XmlRobloxFile`, both of which derive from the `RobloxFile` class.
At this time converting between Binary and XML is not directly supported, but in theory it shouldn't cause too many problems.

```cs
if (file is BinaryRobloxFile)
    Console.WriteLine("This file used Roblox's binary format!");
else
    Console.WriteLine("This file used Roblox's xml format!");
```

This library contains a full implementation of Roblox's DOM, meaning that you can directly iterate over the Instance tree of the file as if you were writing code in Lua for Roblox!
The `RobloxFile` class inherits from the provided `Instance` class in this library, serving as the root entry point to the contents of the file:

```cs
foreach (Instance descendant in file.GetDescendants())
    Console.WriteLine(descendant.GetFullName());
```

You can use type casting to read the properties specific to a derived class of Instance.
Full type coverage is provided for all of Roblox's built-in types under the `RobloxFiles.DataTypes` namespace.
Additionally, all of Roblox's enums are defined under the `RobloxFiles.Enums` namespace.

```cs
Workspace workspace = file.FindFirstChildWhichIsA<Workspace>();

if (workspace != null)
{
    BasePart primary = workspace.PrimaryPart;
    
    if (primary != null)
    {
        primary.CFrame = new CFrame(1, 2, 3);
        primary.Size = new Vector3(4, 5, 6);
    }
    
    workspace.StreamingPauseMode = StreamingPauseMode.ClientPhysicsPause;
    Console.WriteLine($"Workspace.FilteringEnabled: {workspace.FilteringEnabled}");  
}  
```

Property values are populated upon opening a file through `Property` binding objects. 
The read-only dictionary `Instance.Properties` provides a lookup for these bindings, thus allowing for generic iteration over the properties of an Instance!

For example, this function will count all distinct `ContentId` urls in the `Workspace` a given file:
```cs
static void CountAssets(string path)
{
    Console.WriteLine("Opening file...");
    RobloxFile target = RobloxFile.Open(path);

    var workspace = target.FindFirstChildOfClass<Workspace>();
    var assets = new HashSet<string>();

    if (workspace == null)
    {
        Console.WriteLine("No workspace found!");
        Debugger.Break();

        return;
    }

    foreach (Instance inst in workspace.GetDescendants())
    {
        var instPath = inst.GetFullName();
        var props = inst.Properties;

        foreach (Property prop in props)
        {
			// Test if this property's value has a type of ContentId.
            var content = prop.Value as ContentId;

            if (content != null)
            {
                string propName = prop.Key;
                string url = content.Url.Trim();

                var id = Regex
                    .Match(url, pattern)?
                    .Value;

                if (id != null && id.Length > 5)
                    url = "rbxassetid://" + id;

                if (url.Length > 0 && !assets.Contains(url))
                {
                    Console.WriteLine($"[{url}] at {instPath}.{propName}");
                    assets.Add(url);
                }
            }
        }
    }

    Console.WriteLine("Done! Press any key to continue...");
    Console.Read();
}
```

# Tests
The xUnit test project uses [rbx-test-files](https://github.com/rojo-rbx/rbx-test-files) as a pinned submodule in `UnitTest/Fixtures/rbx-test-files`.
Initialize the fixtures and run the tests from the repository root:

```sh
git submodule update --init --recursive
dotnet test RobloxFileFormat.sln --configuration Release
```

Tests cover loading every binary/XML model and place, in-memory save/reload hierarchy checks, representative integer values and object references, and the security capabilities generator.

The structural tests do not guarantee lossless preservation of every property or byte-for-byte output.
Fixture discovery fails if the submodule is missing or empty. No fixture files are modified by the tests.
The GitHub Actions test workflow runs on Windows and Linux and uploads TRX reports even when tests fail.
The two `places/all-instances-415` hierarchy round-trip tests are temporarily skipped because legacy HumanoidDescription conversion adds BodyPartDescription children. Their load tests remain enabled, and the Specials compatibility functionality is unchanged.

To run only the fixture load checks:

```sh
dotnet test UnitTest/RobloxFileFormat.UnitTest.csproj --configuration Release --filter FullyQualifiedName~FixtureLoads
```

# Reliability

This project receives automated updates alongside the [Roblox Client Tracker](https://github.com/MaximumADHD/Roblox-Client-Tracker), with occasional manual fixes. New classes, enums, and properties (especially those that are not intended for developer consumption) are not guaranteed to be stable across version upgrades.