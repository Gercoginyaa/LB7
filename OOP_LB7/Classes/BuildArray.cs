using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_LB7.Classes
{
    class BuildArray
    {
        public BuildArray(int length)
        {
            this._length = length;
            FillArray();
        }

        private readonly int _length;

        private int[] _mas;

        public int[] MyMas
        {
            get { return _mas; }
        }

        public int[] OddMas
        {
            get
            {
                var odd = from i in _mas
                    where i % 2 != 0
                    select i;
                return odd.ToArray();
            }
        }

        public int MaxElement
        {
            get { return _mas.Max(); }
        }

        public int MinElement
        {
            get { return _mas.Min(); }
        }

        public int SumOfMas
        {
            get { return _mas.Sum(); }
        }

        public double AverageOfMas
        {
            get { return _mas.Sum() / _mas.Length; }
        }

        public void FillArray()
        {
            _mas = new int[_length];
            Random iRandom = new Random();

            for (int i = 0; i < _mas.Length; i++)
            {
                _mas[i] = iRandom.Next(-500, 500);
            }
        }

    }
}
