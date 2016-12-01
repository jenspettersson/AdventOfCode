using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Day1
    {
        public int GetLengthOfPath(IEnumerable<string> path)
        {
            var startPosition = new Position(0, 0, Direction.North);
            var moves = GetAllPositionsOnPath(startPosition, path);

            var endPosition = moves.Last();
            
            return  GetLengthBetweenPositions(startPosition, endPosition);
        }

        public int GetLengthToFirstLocationVisitedTwice(IEnumerable<string> path)
        {
            var startPosition = new Position(0, 0, Direction.North);
            var moves = GetAllPositionsOnPath(startPosition, path);

            var groupBy = moves.GroupBy(x => x);

            return 0;
        }

        private IEnumerable<Position> GetAllPositionsOnPath(Position startPosition, IEnumerable<string> path)
        {
            var moves = new List<Position> { startPosition };
            foreach (var instruction in path)
            {
                var currentPosition = moves.Last();
                moves.Add(currentPosition.Move(instruction));
            }

            return moves;
        }

        private static int GetLengthBetweenPositions(Position startPosition, Position endPosition)
        {
            var x = Math.Abs(startPosition.X - endPosition.X);
            var y = Math.Abs(startPosition.Y - endPosition.Y);

            return x + y;
        }
    }

    public class Movement
    {
        private readonly Func<Position, int, Position> _action;

        public Direction Direction { get; }
        public string Turn { get; }

        public Movement(Direction direction, string turn, Func<Position, int, Position> action)
        {
            _action = action;

            Direction = direction;
            Turn = turn;
        }

        public Position Apply(Position position, int length)
        {
            return _action(position, length);
        }
    }

    public class Position
    {
        public int X { get; }
        public int Y { get; }
        public Direction Direction { get; }

        private readonly List<Movement> _movements = new List<Movement>
        {
            new Movement(Direction.North, "L", (position, length) => new Position(position.X - length, position.Y, Direction.West)),
            new Movement(Direction.North, "R", (position, length) => new Position(position.X + length, position.Y, Direction.East)),
            new Movement(Direction.East, "L", (position, length) => new Position(position.X, position.Y + length, Direction.North)),
            new Movement(Direction.East, "R", (position, length) => new Position(position.X, position.Y - length, Direction.South)),
            new Movement(Direction.South, "L", (position, length) => new Position(position.X + length, position.Y, Direction.East)),
            new Movement(Direction.South, "R", (position, length) => new Position(position.X - length, position.Y, Direction.West)),
            new Movement(Direction.West, "L", (position, length) => new Position(position.X, position.Y - length, Direction.South)),
            new Movement(Direction.West, "R", (position, length) => new Position(position.X, position.Y + length, Direction.North))
        };

        public Position(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public Position Move(string instruction)
        {
            string turn = instruction.Substring(0, 1);
            int length = int.Parse(instruction.Substring(1));

            var movement = _movements.First(x => x.Direction == Direction && x.Turn == turn);
            return movement.Apply(this, length);
        }

        public override string ToString()
        {
            return $"X:{X} Y:{Y} Facing:{Direction}";
        }
    }

    public enum Direction
    {
        North,
        East,
        South,
        West
    }
}