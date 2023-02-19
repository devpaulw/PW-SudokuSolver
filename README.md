# PW-Sudoku Solver
## _A sudoku solver made in C# with <3_

PW-Sudoku Solver is a C# project that generate a random sudoku and solve it automatically,

## How does it work

- You fill it with your own sudoku to solve
- The sudoku is represented by a instance of the class `Sudoku`
- You can convert a DoubleArray filled by numbers between 0 and 9 to a instance of `Sudoku` with the function `GetSudokuFromDoubleArray(int[,] dblArr)`
- Empty case are represented by a `0`

## How to test it ?

You can use one of the 4 samples stored on the `SudokuHelper` class

Their name is `GetSodokuSample1` to `GetSodokuSample4`

You can download the project and open it with Visual Studio.

Then you can go to `Program.cs` and change this line :

`Sudoku sudokuTest = SudokuHelper.GetSodokuSample1();`

by the sample you want to test. For example:

`Sudoku sudokuTest = SudokuHelper.GetSodokuSample4();`



## How do it solve the Sudoku

In the `Program.cs`, it create an instance of `SudokuSolver`

`SudokuSolver sudokuSolver = new SudokuSolver();`

That will solve and store the sudoku solved

`sudokuSolver.Solve(sudokuTest);`

You can get a string of the Sudoku's classes by calling them

In our example (the first sample)

`sudokuTest`

will return the solved sudoku 

```2|9|8|5|4|3|1|6|7
7|5|4|6|2|1|8|3|9
1|6|3|8|9|7|4|2|5
5|8|6|1|7|2|3|9|4
3|2|7|4|8|9|6|5|1
4|1|9|3|5|6|2|7|8
9|7|1|2|3|8|5|4|6
6|4|2|9|1|5|7|8|3
8|3|5|7|6|4|9|1|2
```

The project was created and coded by devpaulw 

Documentation : Volko76
