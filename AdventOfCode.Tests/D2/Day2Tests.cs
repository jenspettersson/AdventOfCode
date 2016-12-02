using AdventOfCode.D2;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tests.D2
{
    [TestFixture]
    public class Day2Tests
    {
        [Test, Explicit]
        public void GetResult_Part1()
        {
            string[,] g = {
                {"1", "2", "3"},
                {"4", "5", "6"},
                {"7", "8", "9"}
            };

            var day2 = new Grid(g);

            var instructions = InputReader.ReadLines("Day2");

            string code = day2.GetCode(instructions, new Position(1,1));

            code.Should().Be("36629");
        }

        [Test, Explicit]
        public void GetResult_Part2()
        {
            string[,] g = {
                {"",  "",  "1", "",  "" },
                {"",  "2", "3", "4", "" },
                {"5", "6", "7", "8", "9"},
                {"",  "A", "B", "C", "" },
                {"",  "" , "D", "",  "" }
            };

            var day2 = new Grid(g);

            var instructions = InputReader.ReadLines("Day2");

            string code = day2.GetCode(instructions, new Position(0, 2));

            code.Should().Be("99C3D");
        }

        [Test]
        public void Should_follow_instructions_part_1()
        {
            string[,] g = {
                {"1", "2", "3"},
                {"4", "5", "6"},
                {"7", "8", "9"}
            };

            var day2 = new Grid(g);
            var code = day2.GetCode(new[] {"ULL", "RRDDD", "LURDL", "UUUUD" }, new Position(1, 1));
            code.Should().Be("1985");
        }

        [Test]
        public void Should_follow_instructions_part_2()
        {
            string[,] g = {
                {"",  "",  "1", "",  "" },
                {"",  "2", "3", "4", "" },
                {"5", "6", "7", "8", "9"},
                {"",  "A", "B", "C", "" },
                {"",  "" , "D", "",  "" }
            };
            
            var day2 = new Grid(g);
            var code = day2.GetCode(new[] { "ULL", "RRDDD", "LURDL", "UUUUD" }, new Position(0, 2));
            code.Should().Be("5DB3");
        }
    }
}