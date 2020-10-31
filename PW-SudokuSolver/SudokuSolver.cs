using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW_SudokuSolver
{
    class SudokuSolver
    {
        private Sudoku _sudoku;

        public void Solve(Sudoku sudoku)
        {
            _sudoku = sudoku;
            AddPossibleNumbers();
        }

        void AddPossibleNumbers()
        {
            foreach (SudokuBox box in _sudoku)
            {

            }
        }
    }
}
