//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using PW_SudokuSolver;

//namespace SudokuSolver_UnitTests
//{
//    [TestClass]
//    public class SudokuTests
//    {
//        readonly Sudoku _sudoku1;

//        public SudokuTests()
//        {
//            _sudoku1 = SudokuHelper.GetSodokuSample1();
//        }


//        [TestMethod]
//        public void Indexer_ShouldBeOrdered()
//        {
//            Assert.AreEqual(9, _sudoku1[1, 0].UniqueNumber.Value);
//            Assert.AreEqual(8, _sudoku1[4, 4].UniqueNumber.Value);
//            Assert.AreEqual(7, _sudoku1[6, 7].UniqueNumber.Value);
//        }

//        [TestMethod]
//        public void Enumeration_ShouldMatch()
//        {
//            // Arrange
//            int[] expectedNotEmptyValues = new[] { 9, 8, 3, 6, 2, 1, 3, 3, 9, 2, 5, 4, 8, 9, 6, 4, 5, 6, 3, 8, 4, 2, 7, 3, 4, 9, 1, 2 };
//            List<int> actualValues = new List<int>();

//            // Act
//            int i = 0;
//            foreach (SudokuBox box in _sudoku1)
//            {
//                if (box.Count > 0)
//                {
//                    actualValues.Add(box[0]);
//                    i++;
//                }
//            }

//            // Assert
//            CollectionAssert.AreEqual(expectedNotEmptyValues, actualValues);
//        }

//        [TestMethod]
//        public void GetSquare_ShouldWork()
//        {
//            // Arrange
//            SudokuBox[] expectedSquareBoxes = new SudokuBox[9]
//            {
//                _sudoku1[6, 6], _sudoku1[7, 6], _sudoku1[8, 6],
//                _sudoku1[6, 7], _sudoku1[7, 7], _sudoku1[8, 7],
//                _sudoku1[6, 8], _sudoku1[7, 8], _sudoku1[8, 8],
//            };

//            // Act
//            var actualSquareBoxes = new List<SudokuBox>(_sudoku1.GetSquare(_sudoku1[6, 7]));

//            // Assert
//            CollectionAssert.AreEqual(expectedSquareBoxes, actualSquareBoxes);
//        }

//        [TestMethod]
//        public void GetHorizontalLine_ShouldWork()
//        {
//            // Arrange
//            SudokuBox[] expectedSquareBoxes = new SudokuBox[9]
//            {
//                _sudoku1[0, 4], _sudoku1[1, 4], _sudoku1[2, 4], _sudoku1[3, 4], _sudoku1[4, 4], _sudoku1[5, 4], _sudoku1[6, 4], _sudoku1[7, 4], _sudoku1[8, 4]
//            };

//            // Act
//            var actualSquareBoxes = new List<SudokuBox>(_sudoku1.GetHorizontalLine(_sudoku1[6, 4]));

//            // Assert
//            CollectionAssert.AreEqual(expectedSquareBoxes, actualSquareBoxes);
//        }

//        [TestMethod]
//        public void GetVerticalLine_ShouldWork()
//        {
//            // Arrange
//            SudokuBox[] expectedSquareBoxes = new SudokuBox[9]
//            {
//                _sudoku1[2, 0], _sudoku1[2, 1], _sudoku1[2, 2], _sudoku1[2, 3], _sudoku1[2, 4], _sudoku1[2, 5], _sudoku1[2, 6], _sudoku1[2, 7], _sudoku1[2, 8]
//            };

//            // Act
//            var actualSquareBoxes = new List<SudokuBox>(_sudoku1.GetVerticalLine(_sudoku1[2, 5]));

//            // Assert
//            CollectionAssert.AreEqual(expectedSquareBoxes, actualSquareBoxes);
//        }
//    }
//}
