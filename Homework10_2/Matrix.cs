using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework10_2
{

    enum Way { Right, Down } ;

    class Matrix : IEnumerable<int>
    {
        #region Fields

        private int[,] matrix;
        private int rowCount;
        private int columnCount;

        #endregion

        #region Properties

        public int RowCount
        {
            get { return rowCount; }
            set
            {
                if (value < 0) rowCount = 0;
                else rowCount = value;
            }
        }
        public int ColumnCount
        {
            get { return columnCount; }
            set
            {
                if (value < 0) columnCount = 0;
                else columnCount = value;
            }
        }

        #endregion

        #region Constructors

        public Matrix() : this(default, default) { }

        public Matrix(int[,] matrix)
        {
            RowCount = matrix.GetLength(0);
            ColumnCount = matrix.GetLength(1);
            this.matrix = new int[RowCount, ColumnCount];
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount;  j++)
                {
                    this.matrix[i, j] = matrix[i, j];
                }
            }
        }

        public Matrix(int rowCount, int columnCount)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
            matrix = new int[RowCount, ColumnCount];
        }


        #endregion

        #region Methods

        public void RandomInitialization()
        {
            Random random = new Random();
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    matrix[i, j] = random.Next(1, 10);
                }
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < RowCount; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < ColumnCount; j++)
                    {
                        yield return matrix[i, j];
                    }
                }
                else
                {
                    for (int j = ColumnCount - 1; j >= 0; j--)
                    {
                        yield return matrix[i, j];
                    }
                }
            }
        }

        public IEnumerable<int> GetEnumeratorDiagonalSnake(Way way)
        {
            if(RowCount != ColumnCount)
            {
                throw new ArgumentException("Diagonal snake - impossible. It isn`t a square matrix");
            }
            int n = RowCount;
            if (way == Way.Right)
            {
                for (int line = 0; line < n; line++)
                {
                    if (line % 2 == 0)
                    {
                        int i1 = line;
                        int j1 = 0;
                        for (int i = 0; i < line + 1; i++)
                        {
                            yield return matrix[i1, j1];
                            i1--;
                            j1++;
                        }
                    }
                    else
                    {
                        int i1 = 0;
                        int j1 = line;
                        for (int i = 0; i < line + 1; i++)
                        {
                            yield return matrix[i1, j1];
                            i1++;
                            j1--;
                        }
                    }
                }

                bool isEven = false;
                if (n % 2 == 0) { isEven = true; }

                for (int line = 1; line < n; line++)
                {
                    if (isEven)
                    {
                        if (line % 2 == 0)
                        {
                            int i1 = line;
                            int j1 = n - 1;
                            for (int i = 0; i < n - line; i++)
                            {
                                yield return matrix[i1, j1];
                                i1++;
                                j1--;
                            }
                        }
                        else
                        {
                            int i1 = n - 1;
                            int j1 = line;
                            for (int i = 0; i < n - line; i++)
                            {
                                yield return matrix[i1, j1];
                                i1--;
                                j1++;
                            }
                        }
                    }
                    else
                    {
                        if (line % 2 == 0)
                        {
                            int i1 = n - 1;
                            int j1 = line;
                            for (int i = 0; i < n - line; i++)
                            {
                                yield return matrix[i1, j1];
                                i1--;
                                j1++;
                            }
                        }
                        else
                        {
                            int i1 = line;
                            int j1 = n - 1;
                            for (int i = 0; i < n - line; i++)
                            {
                                yield return matrix[i1, j1];
                                i1++;
                                j1--;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int line = 0; line < n; line++)
                {
                    if (line % 2 == 0)
                    {
                        int i1 = 0;
                        int j1 = line;
                        for (int i = 0; i < line + 1; i++)
                        {
                            yield return matrix[i1, j1];
                            i1++;
                            j1--;
                        }
                    }
                    else
                    {

                        int i1 = line;
                        int j1 = 0;
                        for (int i = 0; i < line + 1; i++)
                        {
                            yield return matrix[i1, j1];
                            i1--;
                            j1++;
                        }
                    }
                }

                bool isEven = false;
                if (n % 2 == 0) { isEven = true; }

                for (int line = 1; line < n; line++)
                {
                    if (isEven)
                    {
                        if (line % 2 == 0)
                        {

                            int i1 = n - 1;
                            int j1 = line;
                            for (int i = 0; i < n - line; i++)
                            {
                                yield return matrix[i1, j1];
                                i1--;
                                j1++;
                            }
                        }
                        else
                        {
                            int i1 = line;
                            int j1 = n - 1;
                            for (int i = 0; i < n - line; i++)
                            {
                                yield return matrix[i1, j1];
                                i1++;
                                j1--;
                            }
                        }
                    }
                    else
                    {
                        if (line % 2 == 0)
                        {

                            int i1 = line;
                            int j1 = n - 1;
                            for (int i = 0; i < n - line; i++)
                            {
                                yield return matrix[i1, j1];
                                i1++;
                                j1--;
                            }
                        }
                        else
                        {
                            int i1 = n - 1;
                            int j1 = line;
                            for (int i = 0; i < n - line; i++)
                            {
                                yield return matrix[i1, j1];
                                i1--;
                                j1++;
                            }
                        }
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            string resultString = "";
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    resultString += matrix[i, j] + "\t";
                }
                resultString += "\n";
            }
            return resultString;
        }

        #endregion
    }
}