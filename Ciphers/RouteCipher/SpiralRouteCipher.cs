using System;

namespace Ciphers.RouteCipher
{
    public class SpiralRouteCipher : ICipher
    {
        private int _rows;
        private int _columns;

        public SpiralRouteCipher() { }

        public SpiralRouteCipher(int rows, int columns) =>
            SetSpiralDimenstions(rows, columns);

        public void SetSpiralDimenstions(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
        }

        public string Decode(string cipherText)
        {
            var desiredLength = _columns * _rows;
            if (cipherText.Length != desiredLength)
                throw new ArgumentException($"Cipher text doesn't match the spiral size, expeted {desiredLength} characters", nameof(cipherText));

            var plainText = new char[cipherText.Length];

            var spiral = new Spiral(_rows, _columns);

            int i = 0, row, col;
            foreach (var c in cipherText)
            {
                plainText[i] = c;

                (row, col) = spiral.Navigate();

                i = row + (col * _rows);
            }

            return new string(plainText);
        }

        public string Encode(string plainText)
        {
            var desiredLength = _columns * _rows;
            var toEncode = plainText.Replace(" ", string.Empty);
            if (toEncode.Length < desiredLength)
            {
                // pad
                var padIdx = 0;
                while (toEncode.Length < desiredLength)
                    toEncode += toEncode[padIdx++ % toEncode.Length];
            }

            var cipherText = string.Empty;
            var spiral = new Spiral(_rows, _columns);
            int row, col;

            for (var i = 0; ; i = row + (col * _rows))
            {
                cipherText += toEncode[i];

                if (cipherText.Length == toEncode.Length)
                    break;

                (row, col) = spiral.Navigate();
            }

            return cipherText;
        }

        private class Spiral
        {
            internal enum Direction
            {
                Nord,
                Est,
                Sud,
                Ovest
            }

            private Direction _direction;
            private int row;
            private int minRow;
            private int maxRow;

            private int col;
            private int minCol;
            private int maxCol;

            public Spiral(int rows, int columns, Direction startingDirection = Direction.Nord)
            {
                _direction = startingDirection;
                maxRow = rows - 1;
                maxCol = columns - 1;
            }

            public (int, int) Navigate()
            {
                switch (_direction)
                {
                    case Direction.Nord:
                        if (row > minRow)
                            row--; // can go backward with rows
                        else
                        {
                            _direction = Direction.Est; // change direction
                            minRow++; // can no more access previous row
                            col++; // start moving trough columns
                        }
                        break;

                    case Direction.Est:
                        if (col < maxCol)
                            col++;
                        else
                        {
                            _direction = Direction.Sud;
                            maxCol--;
                            row++;
                        }
                        break;

                    case Direction.Sud:
                        if (row < maxRow)
                            row++;
                        else
                        {
                            _direction = Direction.Ovest;
                            maxRow--;
                            col--;
                        }
                        break;

                    case Direction.Ovest:
                        if (col > minCol)
                            col--;
                        else
                        {
                            _direction = Direction.Nord;
                            minCol++;
                            row--;
                        }
                        break;
                }

                return (row, col);
            }
        }
    }
}
