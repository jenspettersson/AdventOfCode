using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.D1
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

            var groupBy = moves.GroupBy(x => new { x.X, x.Y});

            var firstVisitedTwice = groupBy.First(x => x.Count() > 1).Select(position => position).First();

            return GetLengthBetweenPositions(startPosition, firstVisitedTwice);
        }

        private IEnumerable<Position> GetAllPositionsOnPath(Position startPosition, IEnumerable<string> path)
        {
            var moves = new List<Position> { startPosition };
            foreach (var instruction in path)
            {
                var currentPosition = moves.Last();
                moves.AddRange(currentPosition.Move(instruction));
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
}