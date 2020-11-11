using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW_SudokuSolver
{
    public class Sudoku : IEnumerable<SudokuBox>
    {
        public const int Size = 9;
        const int SquareSize = 3;

        readonly SudokuBox[] _boxes;

        public SudokuBox this[int x, int y]
        {
            get => _boxes[x + Size * y];
        }

        public event EventHandler<SudokuBox> BoxFound;

        public Sudoku()
        {
            _boxes = new SudokuBox[Size * Size];

            // Fill
            for (int i = 0; i < _boxes.Length; i++)
            {
                SudokuBox sudokuBox = new SudokuBox();
                sudokuBox.Found += (s, e) => BoxFound?.Invoke(this, s as SudokuBox);
                _boxes[i] = sudokuBox;
                
            }
        }

        //public Sudoku(int?[,] nativeNumbers)
        //{
        //    for (int ix = 0; ix < Size; ix++)
        //        for (int iy = 0; iy < Size; iy++)
        //            _boxes[ix + Size * iy]
        //                = nativeNumbers[ix, iy] != null
        //                ? new SudokuBox(nativeNumbers[ix, iy].Value)
        //                : new SudokuBox();

        //}

        public IEnumerable<SudokuBox> GetSquare(SudokuBox box)
        {
            int boxIndex = Array.IndexOf(_boxes, box);
            int x = boxIndex % Size, y = boxIndex / Size;
            int fsnx = x - x % SquareSize, // Find the first square number x
                fsny = y - y % SquareSize;

            for (int i = 0; i < Size; i++)
            {
                int ix = fsnx + i % SquareSize,
                    iy = fsny + i / SquareSize;
                var rb = _boxes[ix + Size * iy];
                if (rb != box)
                    yield return rb;
            }
        }

        public IEnumerable<SudokuBox> GetHorizontalLine(SudokuBox box)
        {
            int boxIndex = Array.IndexOf(_boxes, box);
            int y = boxIndex / Size;
            for (int x = 0; x < Size; x++)
            {
                var rb = _boxes[x + Size * y];
                if (rb != box)
                    yield return rb;
            }
        }

        public IEnumerable<SudokuBox> GetVerticalLine(SudokuBox box)
        {
            int boxIndex = Array.IndexOf(_boxes, box);
            int x = boxIndex % Size;
            for (int y = 0; y < Size; y++)
            {
                var rb = _boxes[x + Size * y];
                if (rb != box)
                    yield return rb;
            }
        }

        public IEnumerable<SudokuBox> GetRelatedBoxes(SudokuBox box)
        {
            return GetSquare(box)
                    .Concat(GetHorizontalLine(box))
                    .Concat(GetVerticalLine(box));
        }

        public IEnumerator<SudokuBox> GetEnumerator()
        {
            return _boxes.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString()
        {
            string[] lines = new string[Size];

            for (int y = 0; y < Size; y++)
            {
                string[] line = new string[Size];
                for (int x = 0; x < Size; x++)
                {
                    if (this[x, y].IsEmpty)
                        line[x] = "?";
                    else
                    {
                        line[x] = string.Join(",", this[x, y].Numbers);
                    }
                }
                lines[y] = string.Join("|", line);
            }

            return string.Join("\n", lines);
        }
    }
}
