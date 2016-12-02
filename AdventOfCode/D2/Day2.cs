using System.Collections.Generic;

namespace AdventOfCode.D2
{
    public class Day2
    {
        private List<List<string>> _keypad = new List<List<string>>
        {
            new List<string> {"1", "2", "3"},
            new List<string> {"4", "5", "6"},
            new List<string> {"7", "8", "9"}
        };

        public string GetCode(string[] instructions)
        {
            var positions = new List<Position>();
            var position = new Position(1, 1);
            foreach (var instruction in instructions)
            {
                foreach (var s in instruction)
                {
                    position = position.Move(s.ToString());
                }

                positions.Add(position);
            }
            string code = "";
            foreach (var p in positions)
            {
                code += _keypad[p.Y][p.X];
            }

            return code;
        }
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position Move(string instruction)
        {
            if (instruction == "U")
            {
                if (Y == 0)
                    return this;
                return new Position(X, Y - 1);
            }
            if (instruction == "D")
            {
                if (Y == 2)
                    return this;
                return new Position(X, Y + 1);
            }
            if (instruction == "L")
            {
                if (X == 0)
                    return this;
                return new Position(X - 1, Y);
            }
            if (instruction == "R")
            {
                if (X == 2)
                    return this;
                return new Position(X + 1, Y);
            }

            return this;
        }
    }
}