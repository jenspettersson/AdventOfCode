using AdventOfCode.D2;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tests.D2
{
    [TestFixture]
    public class Day2Tests
    {
        [Test]
        public void SomeTest()
        {
            var day2 = new Day2();

            var instructions = InputReader.ReadLines("Day2");

            string code = day2.GetCode(instructions);
        }

        [Test]
        public void Foo()
        {
            var day2 = new Day2();
            var code = day2.GetCode(new[] {"ULL", "RRDDD", "LURDL", "UUUUD" });
            code.Should().Be("1985");
        }

        [Test]
        public void Bar()
        {
            var day2 = new Day2();
            var code = day2.GetCode(new[] { "RRDDD" });
            code.Should().Be("9");
        }

        [Test]
        public void Baz()
        {
            var day2 = new Day2();
            var code = day2.GetCode(new[] { "LURDL" });
            code.Should().Be("8");
        }
    }
}