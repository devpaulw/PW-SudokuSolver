using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW_SudokuSolver
{
    public class SudokuSolver
    {
        private Sudoku _sudoku;

        public void Solve(Sudoku sudoku)
        {
            _sudoku = sudoku;
            _sudoku.BoxFound += (s, e) => EnsureConsistencyAround(e);
            AddPossibleNumbers();
            ScanForAlonesNumber();
        }

        void AddPossibleNumbers()
        {
            foreach (SudokuBox box in _sudoku)
            {
                if (box.IsFound) // Don't try to find possible numbers on already found boxes
                    continue;

                List<int> possibleNumbers = Enumerable.Range(1, 9).ToList();

                // Remove impossible numbers
                foreach (SudokuBox relatedBox in _sudoku.GetRelatedBoxes(box))
                {
                    if (relatedBox.UniqueNumber != null)
                        possibleNumbers.Remove(relatedBox.UniqueNumber.Value);
                }

                box.SetNumbers(possibleNumbers.ToArray());
            }
        }

        void EnsureConsistencyAround(SudokuBox box)
        {
            if (box.IsFound)
            {
                foreach (SudokuBox relatedBox in _sudoku.GetRelatedBoxes(box))
                {
                    relatedBox.Numbers.Remove(box.UniqueNumber.Value);
                }
            }
        }

        void ScanForAlonesNumber()
        {
            foreach (SudokuBox box in _sudoku)
            {
                if (box.IsFound)
                    continue;

                foreach (int number in box.Numbers)
                {
                    bool NbrAlone(IEnumerable<SudokuBox> boxes) => !boxes.Any(x => x.Numbers.Contains(number));

                    if (NbrAlone(_sudoku.GetHorizontalLine(box))
                        || NbrAlone(_sudoku.GetVerticalLine(box)) 
                        || NbrAlone(_sudoku.GetSquare(box)))
                    {
                        box.SetNumbers(number);
                        break;
                    }
                }
            }
        }

        //void ScanForIsolatedPairs()
        //{
        //    foreach (SudokuBox box in _sudoku)
        //    {
        //        if (box.IsFound)
        //            continue;

        //        if (box.Numbers.Count == 2)
        //        {
        //            if (_sudoku.GetHorizontalLine(box).Any(x => x.Count))
        //        }
        //    }
        //}
    }
}
