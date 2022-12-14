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
        static string path = @"C:\Users\johnw\Desktop\InteractiveFinal.txt";

        static string[] readText = File.ReadAllLines(path);
        
        static string[] pageElements;
        
        static bool GameOver = false;
        
        static ConsoleKeyInfo choice;

        static int currentPage = 0;


        static void Main(string[] args)
        {

            //the game loop
            while (GameOver == false)
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

                    if (choice.KeyChar == 'b' && pageElements.Length > 1)
                    {
                        currentPage = int.Parse(pageElements[4]);
                    }

                }

            }

        }

        static void DisplayScreen()
        {

            Console.WriteLine(pageElements[0]);

            //when it's not an ending
            if (pageElements.Length > 1)
            {
                Console.WriteLine("WHAT DO YOU DO?");
                Console.Write("Press A:");
                Console.WriteLine(pageElements[1]);
                Console.Write("Press B:");
                Console.WriteLine(pageElements[2]);
            }


            //when it is an ending
            else
            {
                //if it's the true ending.
                if (currentPage == 14)
                {
                    Console.WriteLine("Press any key to quit the game");
                    Console.ReadKey(true);
                    GameOver = true;
                }
                //if it's a normal ending
                else
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Press any key to restart");

                    Console.ReadKey(true);

                    currentPage = 0;
                }
            }

        }

    }
}
