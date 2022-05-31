using System;

namespace Homework3
{
    enum Way { Right, Down } ;

    class Matrix
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

        public Matrix() { }

        public Matrix(int[,] matrix)
        {
            this.matrix = matrix;
        }

        #endregion

        #region Methods

        public void Input()
        {
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    Console.Write("Enter matrix element [{0}][{1}]: ", i, j);
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

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

        public void InputSizeOfMatrix()
        {
            Console.Write("Enter number of rows: ");
            RowCount = int.Parse(Console.ReadLine());
            Console.Write("Enter number of columns: ");
            ColumnCount = int.Parse(Console.ReadLine());
            this.matrix = new int[rowCount, columnCount];
        }

        public void VerticalSnakeInitialization()
        {
            int d = 1;
            for (int j = 0; j < columnCount; j++)
            {
                if (j % 2 == 0)
                {
                    for (int i = 0; i < rowCount; i++)
                    {
                        matrix[i, j] = d;
                        d++;
                    }
                }
                else
                {
                    for (int i = rowCount - 1; i >= 0; i--)
                    {
                        matrix[i, j] = d;
                        d++;
                    }
                }
            }
        }

        public void OutputMatrix()
        {
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        //homework
        public void DiagonalSnakeAutorization(int n, Way way)
        {
            RowCount = n;
            ColumnCount = n;
            matrix = new int[n, n];
            int number = 0;
            if(way == Way.Right)
            {
                for (int line = 0; line < n; line++)
                {
                    if (line % 2 == 0)
                    {
                        int i1 = line;
                        int j1 = 0;
                        for (int i = 0; i < line + 1; i++)
                        {
                            matrix[i1, j1] = ++number;
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
                            matrix[i1, j1] = ++number;
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
                                matrix[i1, j1] = ++number;
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
                                matrix[i1, j1] = ++number;
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
                                matrix[i1, j1] = ++number;
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
                                matrix[i1, j1] = ++number;
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
                            matrix[i1, j1] = ++number;
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
                            matrix[i1, j1] = ++number;
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
                                matrix[i1, j1] = ++number;
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
                                matrix[i1, j1] = ++number;
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
                                matrix[i1, j1] = ++number;
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
                                matrix[i1, j1] = ++number;
                                i1--;
                                j1++;
                            }
                        }
                    }
                }
            }
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