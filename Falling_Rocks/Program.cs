using System;
using System.Collections.Generic;
using System.Threading;

namespace Falling_Rocks
{
    class Program
    {

        struct Dwarf
        {
            public int column, row;

            public Dwarf(int x,int y)
            {
                this.column = x;
                this.row = y;
            }
        }

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
            Console.SetWindowSize(30, 15);//60 columns 40 rows 
            Console.SetBufferSize(30, 15);
            Console.CursorVisible = false;

            bool gameLoop = true;

            Random rand = new Random();

            List<Rock> listOfRocks = new List<Rock>();
            Dwarf dwarf = new Dwarf(Console.WindowWidth / 2, Console.WindowHeight - 1);

            char[] rockSymbols = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-' };// Size = 12

            while (gameLoop)
            {
                //read input
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    if (pressedKey.Key == ConsoleKey.Q)
                    {
                        gameLoop = false;
                        break;//Quit game
                    }
                    else if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        dwarf.column++;
                    }
                    else if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        dwarf.column--;
                    }
                }
                
                int randRockcount = rand.Next(1,2); //rocks on a single Row for appropriate density

                for (int i = 0; i <= randRockcount; i++)
                {
                    int randColumn = rand.Next(0, Console.WindowWidth);
                    int randomRockSymbol = rand.Next(0, 11);

                    listOfRocks.Add(new Rock(randColumn, 0, rockSymbols[randomRockSymbol]));
                } 

                Console.Clear();

                for (int i = 0; i < listOfRocks.Count; i++)
                {
                    Rock currentRock = listOfRocks[i];
                    //collision detect ( 0 )
                    if ((dwarf.column == currentRock.column || dwarf.column + 1 == currentRock.column || dwarf.column + 2 == currentRock.column ) && dwarf.row == currentRock.row + 1)
                    {
                        Console.WriteLine("GAME OVER!");
                        gameLoop = false;
                        break;
                    }
                    else if (currentRock.row >= Console.WindowHeight - 1)
                    {
                        listOfRocks.RemoveAt(i);
                        continue;
                    }
                    //MOVE ROCK DOWN
                    currentRock.row++;

                    //PRINT DWARF
                    Console.SetCursorPosition(dwarf.column, dwarf.row);
                    Console.Write("(0)");

                    listOfRocks[i] = currentRock;
                    //PRINT ROCKS
                    Console.SetCursorPosition(currentRock.column, currentRock.row);
                    Console.Write(currentRock.type);
                }
                Thread.Sleep(150);
            }
        }
    }
}
