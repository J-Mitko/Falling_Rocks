using System;
using System.Collections.Generic;
using System.Threading;

namespace Falling_Rocks
{
    class Program
    {

        struct Rock
        {
            public int column, row;
            public char type;

            public Rock(int x, int y, char type)
            {
                this.column = x;
                this.row = y;
                this.type = type;
            }

        }

        static void Main(string[] args)
        {
            Console.Title = "Falling Rocks";
            Console.SetWindowSize(60, 40);//80 columns 50 rows 
            Console.SetBufferSize(60, 40);
            Console.CursorVisible = false;

            Random rand = new Random();

            List<Rock> listOfRocks = new List<Rock>();
            char[] rockSymbols = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-' };// Size = 12

            while (true)
            {
                
                int randRockcount = rand.Next(1,3); //rocks on a single Row for appropriate density

                for (int i = 0; i <= randRockcount; i++)
                {
                    int randColumn = rand.Next(0, Console.WindowWidth);
                    int randomRockSymbol = rand.Next(0, 11);

                    listOfRocks.Add(new Rock(randColumn, 0, rockSymbols[randomRockSymbol]));
                }
                //hkjhkjhkh
                Console.Clear();

                for (int i = 0; i < listOfRocks.Count; i++)
                {
                    Rock currentRock = listOfRocks[i];

                    if (currentRock.row >= Console.WindowHeight - 1)
                    {
                        listOfRocks.RemoveAt(i);
                        continue;
                    }
                    //MOVE ROCK DOWN
                    currentRock.row++;

                    listOfRocks[i] = currentRock;
                    //PRINT
                    Console.SetCursorPosition(currentRock.column, currentRock.row);
                    Console.Write(currentRock.type);
                }
                Thread.Sleep(300);
            }
        }
    }
}
