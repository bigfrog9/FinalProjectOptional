using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinalProjectOptional
{
    internal class Program
    {
        static string path = @"InteractiveFinal.txt";

        static string[] readText = File.ReadAllLines(path);
        
        static string[] pageElements;
        
        static bool GameOver = false;
        //determines if main menu should be open
        static bool Menu = true;
        
        static ConsoleKeyInfo choice;

        static int currentPage = 0;


        static void Main(string[] args)
        {
            //main menu loop
            while (Menu==true&&GameOver==false)
            {
                MainMenu();
            }

            //the game loop
            while (GameOver == false&&Menu==false)
            {
                pageElements = readText[currentPage].Split(';');

                Console.Clear();

                DisplayScreen();


                if (pageElements.Length > 1)
                {
                    choice = Console.ReadKey(true);

                    if (choice.KeyChar == 'a' && pageElements.Length > 1)
                    {
                        currentPage = int.Parse(pageElements[3]);
                    }

                    else if (choice.KeyChar == 'b' && pageElements.Length > 1)
                    {
                        currentPage = int.Parse(pageElements[4]);
                    }

                    else if (choice.KeyChar == 'c' && pageElements.Length > 1)
                    {
                        GameOver = true;
                    }

                }

            }

        }

        static void MainMenu()
        {
            Console.WriteLine("CAVE OF WISHES");

            Console.WriteLine();

            Console.WriteLine("NEW GAME: A");
            
            Console.WriteLine();

            Console.WriteLine("LOAD GAME: B");

            Console.WriteLine();

            Console.WriteLine("EXIT GAME: C");

            choice = Console.ReadKey(true);

            if (choice.KeyChar == 'a')
            {
                Menu = false;
            }

            if (choice.KeyChar == 'A')
            {
                Menu = false;
            }

            else if(choice.KeyChar == 'b')
            {
                //add a way to load game
            }

            else if (choice.KeyChar == 'B')
            {
                //add a way to load game
            }

            else if (choice.KeyChar == 'c')
            {
                GameOver = true;   
            }

            else if (choice.KeyChar == 'C')
            {
                GameOver = true;
            }

        }

        //the main game
        static void DisplayScreen()
        {
            Console.Write("Press ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("C");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" to exit without saving. Press ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" to save the game");

            //when it's not an ending
            if (pageElements.Length > 1)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(pageElements[0]);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor= ConsoleColor.DarkGreen;
                Console.WriteLine("WHAT DO YOU DO?");
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Press A:");
                Console.WriteLine(pageElements[1]);
                
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("----------");
                Console.ForegroundColor = ConsoleColor.Cyan;
                
                Console.Write("Press B:");
                Console.WriteLine(pageElements[2]);
            }


            //when it is an ending
            else
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                //if it's the true ending.
                if (currentPage == 14)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(pageElements[0]);

                    Console.WriteLine("Press any key to quit the game");
                    Console.ReadKey(true);
                    GameOver = true;
                }
                //if it's a normal ending
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(pageElements[0]);

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Press any key to restart");

                    Console.ReadKey(true);
                    currentPage = 0;
                }
            }

        }

    }
}
