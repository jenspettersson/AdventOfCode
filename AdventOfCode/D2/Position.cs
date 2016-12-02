namespace AdventOfCode.D2
{
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
                return new Position(X, Y - 1);
            }
            if (instruction == "D")
            {
                return new Position(X, Y + 1);
            }
            if (instruction == "L")
            {
                return new Position(X - 1, Y);
            }
            if (instruction == "R")
            {
                return new Position(X + 1, Y);
            }

            return this;
        }

        public override string ToString()
        {
            return $"X:{X} Y:{Y}";
        }
    }
}