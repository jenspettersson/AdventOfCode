namespace AdventOfCode.D2
{
    public class Grid
    {
        private readonly string[,] _grid;
        private readonly int _maxRowIndex;
        private readonly int _maxColumnIndex;

        public Grid(string[,] grid)
        {
            _grid = grid;
            _maxRowIndex = grid.GetLength(0) - 1;
            _maxColumnIndex = grid.GetLength(1) - 1;
        }

        public string GetCode(string[] instructions, Position startPosition)
        {
            string code = "";
            var position = startPosition;
            foreach (var instruction in instructions)
            {
                foreach (var s in instruction)
                {
                    position = Move(position, s.ToString());
                }

                code += _grid.GetValue(position.Y, position.X);
            }

            return code;
        }

        private Position Move(Position position, string s)
        {
            var newPosition = position.Move(s);
            if (newPosition.X <= _maxColumnIndex && newPosition.X >= 0 && newPosition.Y <= _maxRowIndex && newPosition.Y >= 0)
            {
                if(!string.IsNullOrEmpty(_grid.GetValue(newPosition.Y, newPosition.X).ToString()))
                    return newPosition;
            }
            return position;
        }
    }
}