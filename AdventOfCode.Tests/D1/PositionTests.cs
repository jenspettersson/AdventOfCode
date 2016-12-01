using System.Linq;
using AdventOfCode.D1;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode.Tests.D1
{
    [TestFixture]
    public class PositionTests
    {
        [Test]
        public void Move_Right_from_facing_North_should_move_position_right_on_X_axis_and_facing_East()
        {
            var position = new Position(0, 0, Direction.North);
            var newPosition = position.Move("R3").Last();

            newPosition.X.Should().Be(3);
            newPosition.Direction.Should().Be(Direction.East);
        }

        [Test]
        public void Move_Left_from_facing_North_should_move_position_left_on_X_axis_and_facing_West()
        {
            var position = new Position(0, 0, Direction.North);
            var newPosition = position.Move("L3").Last();

            newPosition.X.Should().Be(-3);
            newPosition.Direction.Should().Be(Direction.West);
        }

        [Test]
        public void Move_Right_from_facing_East_should_move_position_down_on_Y_axis_and_facing_South()
        {
            var position = new Position(0, 0, Direction.East);
            var newPosition = position.Move("R3").Last();

            newPosition.Y.Should().Be(-3);
            newPosition.Direction.Should().Be(Direction.South);
        }

        [Test]
        public void Move_Left_from_facing_East_should_move_position_up_on_Y_axis_and_facing_North()
        {
            var position = new Position(0, 0, Direction.East);
            var newPosition = position.Move("L3").Last();

            newPosition.Y.Should().Be(3);
            newPosition.Direction.Should().Be(Direction.North);
        }

        [Test]
        public void Move_Right_from_facing_South_should_move_position_left_on_X_axis_and_facing_West()
        {
            var position = new Position(0, 0, Direction.South);
            var newPosition = position.Move("R3").Last();

            newPosition.X.Should().Be(-3);
            newPosition.Direction.Should().Be(Direction.West);
        }

        [Test]
        public void Move_Left_from_facing_South_should_move_position_right_on_X_axis_and_facing_East()
        {
            var position = new Position(0, 0, Direction.South);
            var newPosition = position.Move("L3").Last();

            newPosition.X.Should().Be(3);
            newPosition.Direction.Should().Be(Direction.East);
        }

        [Test]
        public void Move_Right_from_facing_West_should_move_position_up_on_Y_axis_and_facing_North()
        {
            var position = new Position(0, 0, Direction.West);
            var newPosition = position.Move("R3").Last();

            newPosition.Y.Should().Be(3);
            newPosition.Direction.Should().Be(Direction.North);
        }

        [Test]
        public void Move_Left_from_facing_West_should_move_position_down_on_Y_axis_and_facing_South()
        {
            var position = new Position(0, 0, Direction.West);
            var newPosition = position.Move("L3").Last();

            newPosition.Y.Should().Be(-3);
            newPosition.Direction.Should().Be(Direction.South);
        }
    }
}