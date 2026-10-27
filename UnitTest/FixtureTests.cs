using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace RobloxFiles.UnitTest
{
    public class FixtureTests
    {
        private const string LegacyHierarchySkipReason =
            "Legacy HumanoidDescription conversion adds BodyPartDescription children; hierarchy preservation is not yet supported.";

        private static readonly string FixtureRoot = Path.Combine(
            AppContext.BaseDirectory, "Fixtures", "rbx-test-files");

        public static IEnumerable<object[]> FixtureFiles()
        {
            Assert.True(Directory.Exists(FixtureRoot),
                "Fixture submodule is missing. Run git submodule update --init --recursive before building tests.");

            var extensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                ".rbxm", ".rbxmx", ".rbxl", ".rbxlx"
            };
            
            var files = Directory.EnumerateFiles(FixtureRoot, "*", SearchOption.AllDirectories)
                .Where(path => extensions.Contains(Path.GetExtension(path)))
                .Select(path => Path.GetRelativePath(FixtureRoot, path).Replace('\\', '/'))
                .OrderBy(path => path, StringComparer.Ordinal)
                .ToArray();

            Assert.NotEmpty(files);

            foreach (string file in files)
                yield return new object[] { file };
        }

        public static IEnumerable<object[]> RoundTripFixtureFiles()
        {
            return FixtureFiles().Where(row =>
                (string)row[0] != "places/all-instances-415/binary.rbxl"
                && (string)row[0] != "places/all-instances-415/xml.rbxlx");
        }

        [Theory]
        [MemberData(nameof(FixtureFiles))]
        public void FixtureLoads(string fixture)
        {
            var file = OpenFixture(fixture);

            if (fixture.EndsWith(".rbxmx", StringComparison.Ordinal)
                || fixture.EndsWith(".rbxlx", StringComparison.Ordinal))
                Assert.IsType<XmlRobloxFile>(file);
            else
                Assert.IsType<BinaryRobloxFile>(file);

            var descendants = file.GetDescendants().ToArray();
            Assert.NotEmpty(descendants);
            Assert.All(descendants, instance =>
            {
                Assert.False(string.IsNullOrEmpty(instance.ClassName));
                Assert.NotNull(instance.Parent);
                Assert.Contains(instance, instance.Parent.GetChildren());
            });
        }

        [Theory]
        [MemberData(nameof(RoundTripFixtureFiles))]
        public void FixtureRoundTripPreservesHierarchy(string fixture)
        {
            var original = OpenFixture(fixture);
            var expected = DescribeHierarchy(original);
            var reopened = RoundTrip(original);
            Assert.Equal(original.GetType(), reopened.GetType());
            Assert.Equal(expected, DescribeHierarchy(reopened));
        }

        [Fact(Skip = LegacyHierarchySkipReason)]
        public void LegacyBinaryAllInstancesRoundTripPreservesHierarchy()
        {
            FixtureRoundTripPreservesHierarchy("places/all-instances-415/binary.rbxl");
        }

        [Fact(Skip = LegacyHierarchySkipReason)]
        public void LegacyXmlAllInstancesRoundTripPreservesHierarchy()
        {
            FixtureRoundTripPreservesHierarchy("places/all-instances-415/xml.rbxlx");
        }

        [Theory]
        [InlineData("binary.rbxm")]
        [InlineData("xml.rbxmx")]
        public void IntegerValuesSurviveRoundTrip(string format)
        {
            var original = OpenFixture("models/three-intvalues/" + format);

            foreach (var file in new[] { original, RoundTrip(original) })
            {
                var values = file.GetDescendants().OfType<IntValue>()
                    .Select(instance => instance.Value).OrderBy(value => value).ToArray();
                Assert.Equal(new long[] { -7654321, 1337, 1234567 }, values);
            }
        }

        [Theory]
        [InlineData("binary.rbxm")]
        [InlineData("xml.rbxmx")]
        public void ChildReferencesSurviveRoundTrip(string format)
        {
            var original = OpenFixture("models/ref-child/" + format);

            foreach (var file in new[] { original, RoundTrip(original) })
            {
                var reference = Assert.Single(file.GetDescendants().OfType<ObjectValue>());
                var child = Assert.IsType<Folder>(Assert.Single(reference.GetChildren()));
                Assert.Equal("Ref Target", child.Name);
                Assert.Same(child, reference.Value);
            }
        }

        [Fact]
        public void SecurityCapabilitiesAreGenerated()
        {
            SecurityCapabilitiesTests.Run();
        }

        private static RobloxFile OpenFixture(string fixture)
        {
            return RobloxFile.Open(Path.Combine(FixtureRoot, fixture.Replace('/', Path.DirectorySeparatorChar)));
        }

        private static RobloxFile RoundTrip(RobloxFile file)
        {
            using (var stream = new MemoryStream())
            {
                file.Save(stream);
                return RobloxFile.Open(stream.ToArray());
            }
        }

        private static string[] DescribeHierarchy(RobloxFile file)
        {
            return file.GetDescendants()
                .Select(instance => instance.ClassName + ":" + instance.GetFullName("/"))
                .OrderBy(description => description, StringComparer.Ordinal)
                .ToArray();
        }
    }
}