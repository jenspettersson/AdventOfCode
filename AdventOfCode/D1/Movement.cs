using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.D1
{
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

        public IEnumerable<Position> Apply(Position position, int length)
        {
            var sourceDirection = position.Direction;

            var path = new List<Position> {_action(position, 1)};
            for (var i = 2; i <= length; i++)
            {
                var currentPosition = path.Last();
                path.Add(_action(new Position(currentPosition.X, currentPosition.Y, sourceDirection), i));
            }

            return path;
        }
    }
}