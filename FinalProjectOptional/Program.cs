using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace FinalProjectOptional
{
    internal class Program
    {
        
        static string[] pageElements;
        
        static bool GameOver = false;
        //determines if main menu should be open
        static bool Menu = true;
        
        static ConsoleKeyInfo choice;

        static int currentPage = 0;

        static string pageNumber;


        static void Main(string[] args)
        {
            string path = @"InteractiveFinal.txt";

            string story = @"savegame.txt";

            string[] readText = File.ReadAllLines(path);

            try
            {
                string saveData = File.ReadAllText(story);


            //main menu loop
            while (Menu==true&&GameOver==false)
            {
                MainMenu(story,saveData);

            //the game loop
                while (GameOver == false&&Menu==false)
                {
                    try
                    {
                        pageElements = readText[currentPage].Split(';');
                    }

                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("ERROR: The file has been tampered with. Computer will now explode.");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Not really, but please press any button to overwrite the file. You will unfortunately lose your progress. And will restart the game.");

                            Console.ReadKey(true);
                            File.WriteAllText(story, pageNumber);
                            GameOver = true;

                        }

                        Console.Clear();

                    DisplayScreen();

                    //saving the game
                    if (choice.KeyChar == '1')
                    {
                        pageNumber = currentPage.ToString();

                        File.WriteAllText(story, pageNumber);
                    }
                    //not an ending
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

                        //if the player presses a wrong key it's not really a problem, but this will chastise them
                        else
                        {
                            Console.WriteLine("Oops! That key wasn't an option.");
                        }

                    }
                }

             }

            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("There is no file called 'story.txt in balabalabla. It has now been created. Press any key to exit, and then please open the game again.");
                File.WriteAllText(story, pageNumber);
                Console.ReadKey(true);
            }
        }

        static void MainMenu(string story, string saveData)
        {
            Console.WriteLine("CAVE OF WISHES");

            Console.WriteLine();

            Console.WriteLine("NEW GAME: A");
            
            Console.WriteLine();

            Console.WriteLine("LOAD GAME: B");

            Console.WriteLine();

            Console.WriteLine("EXIT GAME: C");

            choice = Console.ReadKey(true);

            //start the game
            if (choice.KeyChar == 'a')
            {
                Menu = false;
            }

            if (choice.KeyChar == 'A')
            {
                Menu = false;
            }

            //load game from a certain page
            else if(choice.KeyChar == 'b')
            {

                try
                {
                    currentPage = int.Parse(saveData);
                }
                catch
                {
                    Console.WriteLine("ERROR: The file has been tampered with. Computer will now explode.");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Not really, but please press any button to overwrite the file. You will unfortunately lose your progress and have to start from the beginning.");

                    Console.ReadKey(true);

                    pageNumber = currentPage.ToString();

                    File.WriteAllText(story, pageNumber); File.WriteAllText(story, pageNumber);
                    
                    Console.Clear();

                }
                Menu = false;
            }

            else if (choice.KeyChar == 'B')
            {
                //add a way to load game
            }

            //quit the game
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
            Console.Write("1");
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
                    currentPage = 0;
                    Console.Clear();
                    Menu = true;
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
                    Console.Clear();
                    Menu = true;
                }
            }

        }
        
    }
}
