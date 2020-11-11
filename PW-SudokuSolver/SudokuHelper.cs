using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW_SudokuSolver
{
    public static class SudokuHelper
    {
        /// <summary>
        /// Sudoku evaluated level 1/4
        /// EG Sudoku 255 Top+ hors série n°24 - Sudoku n°16
        /// </summary>
        public static Sudoku GetSodokuSample1()
            => GetSudokuFromDoubleArray(new int[Sudoku.Size, Sudoku.Size]
               {
                    { 0, 9, 8, 0, 0, 3, 0, 0, 0 },
                    { 0, 0, 0, 6, 2, 1, 0, 3, 0 },
                    { 0, 0, 3, 0, 9, 0, 0, 2, 0 },
                    { 5, 0, 0, 0, 0, 0, 0, 0, 4 },
                    { 0, 0, 0, 0, 8, 9, 6, 0, 0 },
                    { 4, 0, 0, 0, 5, 6, 0, 0, 0 },
                    { 0, 0, 0, 0, 3, 8, 0, 0, 0 },
                    { 0, 4, 2, 0, 0, 0, 7, 0, 3 },
                    { 0, 0, 0, 0, 0, 4, 9, 1, 2 }
               });

        /// <summary>
        /// Easy Sudoku evaluated level 1/15
        /// Sport Cérébral Sudoku Ludic n°24 - Sudoku n°22
        /// </summary>
        public static Sudoku GetSodokuSample2()
        => GetSudokuFromDoubleArray(new int[Sudoku.Size, Sudoku.Size]
           { // eg sudoku 255 top+ hors série n°24 - sudoku n°16
                    { 1, 5, 0, 0, 2, 3, 0, 9, 6 },
                    { 0, 0, 9, 4, 0, 0, 8, 0, 7 },
                    { 4, 0, 0, 0, 7, 0, 3, 0, 0 },
                    { 3, 0, 6, 7, 9, 0, 0, 0, 8 },
                    { 0,0,4,1,0,0,6,0,5 },
                    { 5,7,0,0,0,4,0,1,0 },
                    { 7,8,0,2,0,9,0,6,0 },
                    { 2,0,0,0,0,0,1,0,0 },
                    { 0,0,1,5,6,0,0,3,2 }
           });

        /// <summary>
        /// Easy Sudoku evaluated level 1/15
        /// Sport Cérébral Sudoku Ludic n°1 - Sudoku n°22
        /// </summary>
        public static Sudoku GetSodokuSample3()
        => GetSudokuFromDoubleArray(new int[Sudoku.Size, Sudoku.Size]
           { // eg sudoku 255 top+ hors série n°24 - sudoku n°16
                    { 2, 1, 0, 5, 0, 9, 0, 3, 4 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 9 },
                    { 5, 3, 0, 0, 4, 6, 1, 7, 2 },
                    { 7, 8, 0, 2, 0, 0, 3, 0, 0 },
                    { 9, 0, 0, 0, 6, 8, 2, 1, 0 },
                    { 0, 5, 2, 0, 1, 4, 0, 8, 0 },
                    { 1, 0, 0, 0, 0, 3, 4, 5, 8 },
                    { 3, 9, 0, 0, 8, 0, 6, 2, 0 },
                    { 0, 2, 4, 0, 5, 1, 0, 9, 0 }
           });

        /// <summary>
        /// Sudoku evaluated level 1/4
        /// EG Sudoku 255 Top+ hors série n°11 - Sudoku n°16
        /// </summary>
        public static Sudoku GetSodokuSample4()
        => GetSudokuFromDoubleArray(new int[Sudoku.Size, Sudoku.Size]
           { // eg sudoku 255 top+ hors série n°24 - sudoku n°16
                    { 5, 0, 0, 0, 0, 6, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 5, 6, 3, 0 },
                    { 8, 0, 2, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 5, 1, 2, 0, 0, 0, 0 },
                    { 0, 1, 0, 0, 5, 0, 9, 0, 2 },
                    { 0, 2, 0, 0, 0, 7, 0, 6, 0 },
                    { 2, 3, 1, 0, 0, 0, 0, 0, 6 },
                    { 0, 0, 0, 7, 1, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 4, 0, 9 }
           });

        private static Sudoku GetSudokuFromDoubleArray(int[,] dblArr)
        {
            var sudoku = new Sudoku();

            for (int y = 0; y < Sudoku.Size; y++)
                for (int x = 0; x < Sudoku.Size; x++)
                    if (dblArr[y, x] != 0)
                        sudoku[x, y].SetNumbers(dblArr[y, x]);

            return sudoku;
        }
    }
}
