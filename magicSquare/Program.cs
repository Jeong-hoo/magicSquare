using System;

namespace magicSquare
{
    class Program
    {
        const int MAX_COUNT = 3;

        public struct RowColumn
        {
            public int rc;
            public RowColumn(int rC=0)
            {
                this.rc = rC;
            }

            public static RowColumn operator ++(RowColumn rowCol)
            {
                rowCol.rc++;

                if (rowCol.rc > MAX_COUNT - 1)
                    rowCol.rc = 0;

                return rowCol;
            }
            public static RowColumn operator --(RowColumn rowCol)
            {
                rowCol.rc--;

                if (rowCol.rc < 0)
                    rowCol.rc = MAX_COUNT - 1;

                return rowCol;
            }
        }
        static void Main(string[] args)
        {
            int[,] arr = new int[MAX_COUNT, MAX_COUNT];

            for(int i=0;i<arr.GetLength(0);i++)
            {
                for(int j =0;j<arr.GetLength(1);j++)
                {
                    arr[i,j] = -1;
                }
            }

            int count = 1;
            int maxXCount = MAX_COUNT * MAX_COUNT;

            RowColumn rowPos = new RowColumn();
            RowColumn colPos = new RowColumn(MAX_COUNT / 2);

            //start
            arr[rowPos.rc, colPos.rc] = 1;

            while (count < maxXCount)
            {
                rowPos--;
                colPos++;

                if (arr[rowPos.rc, colPos.rc] < 0)
                {
                    arr[rowPos.rc, colPos.rc] = ++count;
                }
                else
                {
                    rowPos++;
                    colPos--;
                    arr[(++rowPos).rc, colPos.rc] = ++count;
                }
            }
            ShowSquare(arr);
        }
        static void ShowSquare(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j]}\t");
                }
                Console.WriteLine("");
            }
        }
    }
}
