using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW_SudokuSolver
{
    class SudokuBox
    {
        public List<int> PossibleNumbers { get; } = new List<int>();

        public int? UniqueNumber
        {
            get => PossibleNumbers.Count == 1 ? (int?)PossibleNumbers[0] : null;
            set
            {
                if (!value.HasValue)
                    throw new ArgumentNullException(nameof(value));

                PossibleNumbers.Clear();
                PossibleNumbers.Add(value.Value);
            }
        }

        public bool IsFound => UniqueNumber != null;
        public bool IsEmpty => PossibleNumbers.Count == 0;

        public SudokuBox() { }

        public SudokuBox(int uniqueNumber)
        {
            PossibleNumbers.Add(uniqueNumber);
        }
    }
}
