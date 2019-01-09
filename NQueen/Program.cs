using System;

namespace NQueen
{
    public static class Program
    {
        public static int tableSize = 9;
        public static char[,] table = new char[tableSize, tableSize];
        public static char Queen = 'Q';
        public static char CanNotMove = '.';
        public static char CanMove = ' ';

        public static void Main(string[] args)
        {
            InitBoard(3, 3);
            PrintBoard();
            Console.ReadKey();
        }

        public static void InitBoard(int x = 0, int y = 0)
        {
            for (int i = 0; i < tableSize; i++)
            {
                for (int j = 0; j < tableSize; j++)
                {
                    if (i == x && y == j)
                    {
                        table[i, j] = Queen;

                    }
                    else
                    {
                        table[i, j] = CanMove;
                    }
                }
            }
            MarkCanNotMovePlaces(x, y);
        }

        public static void PrintBoard()
        {
            for (int i = -1; i < tableSize + 1; i++)
            {
                Console.Write('|');
                for (int j = 0; j < tableSize; j++)
                {
                    if (i == -1 || i == tableSize)
                    {
                        Console.Write("--");
                    }
                    else
                    {
                        Console.Write(table[i, j].ToString() + ' ');
                    }
                }
                Console.WriteLine('|');
            }
        }

        public static void MarkCanNotMovePlaces(int x = 0, int y = 0)
        {
            for (int i = 0; i < tableSize; i++)
            {
                if (table[x, i] == CanMove)
                {
                    table[x, i] = CanNotMove;
                }
                if (table[i, y] == CanMove)
                {
                    table[i, y] = CanNotMove;
                }
                if (x - i >= 0 && y + i < tableSize && table[x - i, y + i] == CanMove)
                {
                    table[x - i, y + i] = CanNotMove;
                }
                if (x + i < tableSize && y - i >= 0  && table[x + i, y - i] == CanMove)
                {
                    table[x + i, y - i] = CanNotMove;
                }
                if (x - i >= 0 && y - i >= 0 && table[x - i, y - i] == CanMove)
                {
                    table[x - i, y - i] = CanNotMove;
                }
                if (x + i < tableSize && y + i < tableSize && table[x + i, y + i] == CanMove)
                {
                    table[x + i, y + i] = CanNotMove;
                }
            }
        }
    }
}
