﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace NQueen
{
    public static class Program
    {
        public static int tableSize = 30;
        public static List<List<char[,]>> solutionHistory = new List<List<char[,]>>();
        public static char Queen = 'Q';
        public static char CanNotMove = '.';
        public static char CanMove = ' ';
        public static Random random = new Random();

        public static void Main(string[] args)
        {
            bool solved = false;
            do {
                var t = TryToSolve();
                solved = t.Item1;
                solutionHistory.Add(t.Item2);
                PrintBoard(t.Item3, solved == false);
            } while (solved == false);
            Console.ReadKey();
        }

        public static (bool, List<char[,]>, char[,]) TryToSolve()
        {
            char[,] table = new char[tableSize, tableSize];
            List<char[,]> tableHistory = new List<char[,]>();
            var x = random.Next() % tableSize;
            var y = random.Next() % tableSize;

            InitBoard(table, x, y);
            tableHistory.Add(CloneBoard(table));

            while (CountGivenChar(CanMove, table) > 0)
            {
                var available = ListGivenCharPositions(CanMove, table);
                var next = random.Next() % available.Count;

                table[available[next].Item1, available[next].Item2] = Queen;
                MarkCanNotMovePlaces(table, available[next].Item1, available[next].Item2);

            }
            return (CountGivenChar(Queen, table) == tableSize, tableHistory,table);
        }

        public static int CountGivenChar(char ch, char[,] table)
        {
            int count = 0;
            for (int i = 0; i < tableSize; i++)
            {
                for (int j = 0; j < tableSize; j++)
                {
                    if(table[i,j]==ch)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static List<(int,int)> ListGivenCharPositions(char ch, char[,] table)
        {
            var r = new List<(int,int)>();
            for (int i = 0; i < tableSize; i++)
            {
                for (int j = 0; j < tableSize; j++)
                {
                    if (table[i, j] == ch)
                    {
                        r.Add((i,j));
                    }
                }
            }
            return r;
        }

        public static void InitBoard(char[,] table, int x = 0, int y = 0)
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
            MarkCanNotMovePlaces(table, x, y);
        }

        public static char[,] CloneBoard(char[,] table)
        {
            var t = new char[tableSize, tableSize];
            for (int i = 0; i < tableSize; i++)
            {
                for (int j = 0; j < tableSize; j++)
                {
                    t[i, j] = table[i, j];
                }
            }
            return t;
        }

        public static void PrintBoard(char[,] table, bool clean = true)
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
            if (clean)
            {
                Thread.Sleep(100);
                Console.Clear();
            }
        }

        public static void MarkCanNotMovePlaces(char[,] table, int x = 0, int y = 0)
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
