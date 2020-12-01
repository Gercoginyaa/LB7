using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_LB7_2.Classes
{
    class MyMatrix
    {
        public MyMatrix(int Rows, int Collums)
        {
            _matrix=new int[Rows,Collums];
            FillBaseMatrix();
        }

        private int[,] _matrix;

        public int Rows
        {
            get
            {
                return _matrix.GetLength(0);
            }
        }

        public int Collums
        {
            get
            {
                return _matrix.GetLength(1);
            }
        }

        public string GetBaseMatrix()
        {
            string result = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Collums; j++)
                {
                    result += _matrix[i, j].ToString()+" ";
                }

                result += "\n";
            }
            return result;
        }

        private void FillBaseMatrix()
        {
            Random iRandom = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Collums; j++)
                {
                    _matrix[i, j] = iRandom.Next(0, 9);
                }
            }
        }

        public MyMatrix GetDerMatrix1()
        {
            Random jRandom = new Random();
            int collums = jRandom.Next(1, 25);

            MyMatrix matrix1 = new MyMatrix(this.Rows,collums);
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Collums; j++)
                {
                    if (j> this.Collums-1)
                        continue;
                    matrix1._matrix[i, j] = this._matrix[i, j];
                }
            }

            return matrix1;
        }
        public MyMatrix GetDerMatrix2()
        {
            Random jRandom = new Random();
            int rows = jRandom.Next(1, 25);

            MyMatrix matrix1 = new MyMatrix(rows, this.Collums);

            for (int i = 0; i < matrix1.Rows; i++)
            {
                if (i > this.Rows-1)
                    continue;
                for (int j = 0; j < matrix1.Collums; j++)
                {
                    matrix1._matrix[i, j] = this._matrix[i, j];
                }
            }

            return matrix1;
        }
        public MyMatrix GetDerMatrix3()
        {
            Random jRandom = new Random();
            int rows = jRandom.Next(1, 25);
            int collums = jRandom.Next(1, 25);

            MyMatrix matrix1 = new MyMatrix(rows, collums);

            for (int i = 0; i < matrix1.Rows; i++)
            {
                if (i > this.Rows-1)
                    continue;
                for (int j = 0; j < matrix1.Collums; j++)
                {
                    if (j > this.Collums-1)
                        continue;
                    matrix1._matrix[i, j] = this._matrix[i, j];
                }
            }

            return matrix1;
        }
    }
}
