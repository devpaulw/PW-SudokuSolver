using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW_SudokuSolver
{
    class Sudoku : IEnumerable<SudokuBox>
    {
        const int Size = 9;
        const int SquareSize = 3;

        readonly SudokuBox[] _boxes;

        public SudokuBox this[int x, int y]
        {
            get => _boxes[x + Size * y];
        }

        // Check if the grid is full
        public bool IsDone => !_boxes.Any(box => box.IsEmpty);

        public Sudoku()
        {
            _boxes = Enumerable.Repeat(new SudokuBox(), Size * Size).ToArray();
        }

        public Sudoku(int?[,] nativeNumbers)
        {
            for (int ix = 0; ix < Size; ix++)
                for (int iy = 0; iy < Size; iy++)
                    _boxes[ix + Size * iy] 
                        = nativeNumbers[ix, iy] != null 
                        ? new SudokuBox(nativeNumbers[ix, iy].Value) 
                        : new SudokuBox();

        }

        public IEnumerable<SudokuBox> GetSquare(SudokuBox box)
        {
            int boxIndex = Array.IndexOf(_boxes, box);
            int x = boxIndex / Size, y = boxIndex % Size;
            int fsnx = x - x % SquareSize, // Find the first square number x
                fsny = y - y % SquareSize;

            for (int i = 0; i < Size; i++)
            {
                int ix = fsnx + i % SquareSize,
                    iy = fsny + i / SquareSize;
                yield return _boxes[ix + Size * iy];
            }
        }

        public IEnumerable<SudokuBox> GetHorizontalLine(SudokuBox box)
        {
            int boxIndex = Array.IndexOf(_boxes, box);
            int y = boxIndex % Size;
            for (int x = 0; x < Size; x++)
                yield return _boxes[x + Size * y];
        }

        public IEnumerable<SudokuBox> GetVerticalLine(SudokuBox box)
        {
            int boxIndex = Array.IndexOf(_boxes, box);
            int x = boxIndex / Size;
            for (int y = 0; y < Size; y++)
                yield return _boxes[x + Size * y];
        }

        public IEnumerator<SudokuBox> GetEnumerator()
        {
            return _boxes.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
