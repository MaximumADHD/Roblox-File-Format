using System;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using RobloxFiles.SourceGenerators;

namespace RobloxFiles.UnitTest
{
    static class SecurityCapabilitiesTests
    {
        public static void Run()
        {
            CheckCurrentCapabilities();
            CheckGenerator();
            Console.WriteLine("Security capabilities generator checks passed.");
        }

        private static void CheckCurrentCapabilities()
        {
            var sourceFields = typeof(Enums.SecurityCapability).GetFields(BindingFlags.Public | BindingFlags.Static);
            var flags = typeof(SecurityCapabilities);
            var flagFields = flags.GetFields(BindingFlags.Public | BindingFlags.Static);

            Assert(flags.IsDefined(typeof(FlagsAttribute)), "Generated enum must have FlagsAttribute.");
            Assert(Enum.GetUnderlyingType(flags) == typeof(ulong), "Generated flags must be 64-bit.");
            Assert(sourceFields.Length == flagFields.Length, "All source capabilities must be generated.");

            foreach (var source in sourceFields)
            {
                var target = flags.GetField(source.Name);
                Assert(target != null, "Missing capability: " + source.Name);
                int bitIndex = Convert.ToInt32(source.GetRawConstantValue());
                Assert((ulong)target.GetRawConstantValue() == (1UL << bitIndex), "Incorrect mask: " + source.Name);
                Assert(target.IsDefined(typeof(ObsoleteAttribute)) == source.IsDefined(typeof(ObsoleteAttribute)),
                    "Incorrect deprecation: " + source.Name);
            }
        }

        private static void CheckGenerator()
        {
            var validSource = @"
                namespace RobloxFiles.Enums
                {
                    public enum SecurityCapability
                    {
                        First = 0,
                        [System.Obsolete(""Use First.\nNew line."", false, DiagnosticId = ""TEST001"")]
                        Deprecated = 31,
                        @class = 32,
                        Last = 63,
                    }
                }";
            
            var valid = RunGenerator(validSource, out var output);
            Assert(valid.Diagnostics.IsEmpty, "Valid capabilities must not report generator diagnostics.");
            Assert(!output.GetDiagnostics().Any(diagnostic => diagnostic.Severity == DiagnosticSeverity.Error), "Generated source must compile.");

            var generated = output.GetTypeByMetadataName("RobloxFiles.SecurityCapabilities");
            Assert(generated != null, "The flags enum must be generated.");
            Assert(GetMask(generated, "First") == 1UL, "Bit zero must not be an empty mask.");
            Assert(GetMask(generated, "class") == (1UL << 32), "Bit 32 must not wrap to bit zero.");
            Assert(GetMask(generated, "Last") == (1UL << 63), "Bit 63 must be supported.");

            var deprecated = generated.GetMembers("Deprecated").Single().GetAttributes().Single();
            Assert(deprecated.ConstructorArguments[0].Value.Equals("Use First.\nNew line."), "Obsolete messages must be preserved and escaped.");
            Assert(deprecated.NamedArguments.Single().Value.Value.Equals("TEST001"), "Named obsolete arguments must be preserved.");

            var invalid = RunGenerator(@"
                namespace RobloxFiles.Enums
                {
                    public enum SecurityCapability : long 
                    {
                        Negative = -1,
                        TooLarge = 64
                    }
                }", out output);
            
            Assert(invalid.Diagnostics.Count(diagnostic => diagnostic.Id == "RFFSG001"
                && diagnostic.Severity == DiagnosticSeverity.Error) == 2,
                "Negative and overflowing bit indexes must report build errors.");

            var unrelated = RunGenerator("namespace Other { public enum SecurityCapability { First } }", out output);
            Assert(unrelated.Results.Single().GeneratedSources.IsEmpty, "Unrelated enums must not generate Roblox flags.");
        }

        private static GeneratorDriverRunResult RunGenerator(string source, out Compilation output)
        {
            var compilation = CSharpCompilation.Create(
                "GeneratorChecks",
                new[] { CSharpSyntaxTree.ParseText(source, new CSharpParseOptions(LanguageVersion.CSharp7_3)) },
                new[] { MetadataReference.CreateFromFile(typeof(object).Assembly.Location) },
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
            
            GeneratorDriver driver = CSharpGeneratorDriver.Create(
                new[] { new SecurityCapabilitiesGenerator().AsSourceGenerator() },
                parseOptions: new CSharpParseOptions(LanguageVersion.CSharp7_3));
            
            driver = driver.RunGeneratorsAndUpdateCompilation(
                compilation,
                out output,
                out var diagnostics
            );

            return driver.GetRunResult();
        }

        private static ulong GetMask(INamedTypeSymbol flags, string name)
        {
            return (ulong)((IFieldSymbol)flags.GetMembers(name).Single()).ConstantValue;
        }

        private static void Assert(bool condition, string message)
        {
            if (!condition) throw new InvalidOperationException(message);
        }
    }
}