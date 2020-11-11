using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW_SudokuSolver
{
    public class SudokuBox
    {
        private readonly ObservableHashSet<int> _numbers = new ObservableHashSet<int>();

        public ISet<int> Numbers => _numbers;
        public int? UniqueNumber
        {
            get => Numbers.Count == 1 ? (int?)Numbers.First() : null;
        }

        public bool IsFound => UniqueNumber != null;
        public bool IsEmpty => Numbers.Count == 0;

        public event EventHandler Found;

        public SudokuBox()
        {
            _numbers.CollectionChanged += Numbers_CollectionChanged;
        }

        private void Numbers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsFound)
                Found?.Invoke(this, EventArgs.Empty);
        }

        public void SetNumbers(params int[] numbers)
        {
            _numbers.Clear();
            _numbers.AddRange(numbers);
        }

        public override string ToString()
        {
            return "Possible Numbers: {" + string.Join(", ", Numbers) + " }";
        }
    }
}
