using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW_SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sudoku[] sudokus = new[]
            //{

            //}

            Sudoku sudokuTest = SudokuHelper.GetSodokuSample1();
            Console.WriteLine("Sudoku to solve\n" + sudokuTest);
            SudokuSolver sudokuSolver = new SudokuSolver();
            sudokuSolver.Solve(sudokuTest);
            Console.WriteLine("\nSolved sudoku\n" + sudokuTest);
            Console.ReadKey();
        }
    }
}
