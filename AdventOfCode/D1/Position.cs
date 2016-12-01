using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.D1
{
    public class Position
    {
        public int X { get; }
        public int Y { get; }
        public Direction Direction { get; }

        private readonly List<Movement> _movementRules = new List<Movement>
        {
            new Movement(Direction.North, "L", (position, length) => new Position(position.X - 1, position.Y, Direction.West)),
            new Movement(Direction.North, "R", (position, length) => new Position(position.X + 1, position.Y, Direction.East)),
            new Movement(Direction.East, "L", (position, length) => new Position(position.X, position.Y + 1, Direction.North)),
            new Movement(Direction.East, "R", (position, length) => new Position(position.X, position.Y - 1, Direction.South)),
            new Movement(Direction.South, "L", (position, length) => new Position(position.X + 1, position.Y, Direction.East)),
            new Movement(Direction.South, "R", (position, length) => new Position(position.X - 1, position.Y, Direction.West)),
            new Movement(Direction.West, "L", (position, length) => new Position(position.X, position.Y - 1, Direction.South)),
            new Movement(Direction.West, "R", (position, length) => new Position(position.X, position.Y + 1, Direction.North))
        };

        public Position(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public IEnumerable<Position> Move(string instruction)
        {
            string turn = instruction.Substring(0, 1);
            int length = int.Parse(instruction.Substring(1));

            var movement = _movementRules.First(x => x.Direction == Direction && x.Turn == turn);
            return movement.Apply(this, length);
        }
        
        public override string ToString()
        {
            return $"X:{X} Y:{Y} Facing:{Direction}";
        }
    }
}