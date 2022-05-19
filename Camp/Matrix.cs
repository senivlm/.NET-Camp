using System;

namespace Camp
{
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
            for(int i = 0; i < rowCount; i++)
            {
                for(int j = 0; j < columnCount; j++)
                {
                    Console.Write("Enter matrix element [{0}][{1}]: ", i, j);
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        public void RandomInitialization()
        {
            Random random = new Random();
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    matrix[i, j] = random.Next(1, 10);
                }
            }
        }

        public void InputSizeOfMatrix()
        {
            Console.Write("Enter number of rows: ");
            rowCount = int.Parse(Console.ReadLine());
            Console.Write("Enter number of columns: ");
            columnCount = int.Parse(Console.ReadLine());
            this.matrix = new int[rowCount, columnCount];
        }

        public void VerticalSnakeInitialization()
        {
            int d = 1;
            for (int j = 0; j < columnCount; j++)
            {
                if(j % 2 == 0)
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

        #endregion
    }
}
