using System.Linq;
using AdventOfCode.D1;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tests.D1
{
    [TestFixture]
    public class Day1Tests
    {
        [Test, Explicit]
        public void GetResult_Part1()
        {
            var read = InputReader.Read("day1");
            var instructions = read.Split(',').Select(x => x.Trim());

            var day1 = new Day1();
            var lengthOfPath = day1.GetLengthOfPath(instructions);

            lengthOfPath.Should().Be(242);
        }

        [Test, Explicit]
        public void GetResult_Part2()
        {
            var read = InputReader.Read("day1");
            var instructions = read.Split(',').Select(x => x.Trim());

            var day1 = new Day1();
            var lengthOfPath = day1.GetLengthToFirstLocationVisitedTwice(instructions);

            lengthOfPath.Should().Be(150);
        }

        [Test]
        [TestCase("R2, L3", 5)]
        [TestCase("R2, R2, R2", 2)]
        [TestCase("R5, L5, R5, R3", 12)]
        public void Follow_specific_path_should_return_correct_length(string instruction, int expectedLength)
        {
            var day1 = new Day1();
            var length = day1.GetLengthOfPath(instruction.Split(',').Select(x => x.Trim()));

            length.Should().Be(expectedLength);
        }

        [Test]
        public void Should_return_length_to_first_position_visited_twice()
        {
            var day1 = new Day1();
            var length = day1.GetLengthToFirstLocationVisitedTwice(new[] {"R8", "R4", "R4", "R8"});

            length.Should().Be(4);
        }
    }
}
