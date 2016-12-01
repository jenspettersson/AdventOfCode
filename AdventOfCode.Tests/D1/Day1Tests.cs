using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tests.D1
{
    [TestFixture]
    public class Day1Tests
    {
        [Test]
        public void GetResult()
        {
            var read = InputReader.Read("day1");
            var instructions = read.Split(',').Select(x => x.Trim());

            var day1 = new Day1();
            var lengthOfPath = day1.GetLengthOfPath(instructions);
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

    [TestFixture]
    public class PositionTests
    {
        [Test]
        public void Move_Right_from_facing_North_should_move_position_right_on_X_axis_and_facing_East()
        {
            var position = new Position(0, 0, Direction.North);
            var newPosition = position.Move("R3");

            newPosition.X.Should().Be(3);
            newPosition.Direction.Should().Be(Direction.East);
        }

        [Test]
        public void Move_Left_from_facing_North_should_move_position_left_on_X_axis_and_facing_West()
        {
            var position = new Position(0, 0, Direction.North);
            var newPosition = position.Move("L3");

            newPosition.X.Should().Be(-3);
            newPosition.Direction.Should().Be(Direction.West);
        }

        [Test]
        public void Move_Right_from_facing_East_should_move_position_down_on_Y_axis_and_facing_South()
        {
            var position = new Position(0, 0, Direction.East);
            var newPosition = position.Move("R3");

            newPosition.Y.Should().Be(-3);
            newPosition.Direction.Should().Be(Direction.South);
        }

        [Test]
        public void Move_Left_from_facing_East_should_move_position_up_on_Y_axis_and_facing_North()
        {
            var position = new Position(0, 0, Direction.East);
            var newPosition = position.Move("L3");

            newPosition.Y.Should().Be(3);
            newPosition.Direction.Should().Be(Direction.North);
        }

        [Test]
        public void Move_Right_from_facing_South_should_move_position_left_on_X_axis_and_facing_West()
        {
            var position = new Position(0, 0, Direction.South);
            var newPosition = position.Move("R3");

            newPosition.X.Should().Be(-3);
            newPosition.Direction.Should().Be(Direction.West);
        }

        [Test]
        public void Move_Left_from_facing_South_should_move_position_right_on_X_axis_and_facing_East()
        {
            var position = new Position(0, 0, Direction.South);
            var newPosition = position.Move("L3");

            newPosition.X.Should().Be(3);
            newPosition.Direction.Should().Be(Direction.East);
        }

        [Test]
        public void Move_Right_from_facing_West_should_move_position_up_on_Y_axis_and_facing_North()
        {
            var position = new Position(0, 0, Direction.West);
            var newPosition = position.Move("R3");

            newPosition.Y.Should().Be(3);
            newPosition.Direction.Should().Be(Direction.North);
        }

        [Test]
        public void Move_Left_from_facing_West_should_move_position_down_on_Y_axis_and_facing_South()
        {
            var position = new Position(0, 0, Direction.West);
            var newPosition = position.Move("L3");

            newPosition.Y.Should().Be(-3);
            newPosition.Direction.Should().Be(Direction.South);
        }
    }
}
