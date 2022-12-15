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

            string story2 = @"savegame2.txt";

            string[] readText = File.ReadAllLines(path);

            try
            {
                string saveData2 = File.ReadAllText(story2);

            }
            catch
            {
                pageNumber = currentPage.ToString();

                Console.WriteLine("There is no second save file. It has now been created. Press any key to continue.");
                File.WriteAllText(story2, pageNumber);
                Console.ReadKey(true);
                Console.Clear();
                Menu = true;
            }

            try
            {
                string saveData = File.ReadAllText(story);

                try
                {
                    pageElements = readText[currentPage].Split(';');
                }
                catch
                {
                    Console.WriteLine("Something has gone wrong with the main text file. Please delete all local files and redownload the game.");
                    Console.WriteLine("Press any key to close");
                    Console.ReadKey(true);
                    GameOver = true;
                }
                if (pageElements.Length == 0)
                {
                    Console.WriteLine("Something has gone wrong with the main text file. Please delete all local files and redownload the game.");
                    Console.WriteLine("Press any key to close");
                    Console.ReadKey(true);
                    GameOver = true;
                }
                else if (pageElements.Length > 5)
                {
                    Console.WriteLine("Something has gone wrong with the main text file. Please delete all local files and redownload the game.");
                    Console.WriteLine("Press any key to close");
                    Console.ReadKey(true);
                    GameOver = true;
                }
                //main menu loop
                while (Menu==true&&GameOver==false)
                {
                    MainMenu(story,saveData);

                //the game loop
                    while (GameOver == false&&Menu==false)
                    {
                        if(pageElements.Length==0)
                        {
                            Console.WriteLine("Something has gone wrong with the main text file. Please delete all local files and redownload the game.");
                            Console.WriteLine("Press any key to close");
                            Console.ReadKey(true);
                            GameOver = true;
                        }
                        else if (pageElements.Length > 5)
                        {
                            Console.WriteLine("Something has gone wrong with the main text file. Please delete all local files and redownload the game.");
                            Console.WriteLine("Press any key to close");
                            Console.ReadKey(true);
                            GameOver = true;
                        }

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
                            Console.WriteLine();
                            Console.WriteLine("If the problem is still not fixed, the problem is probably with the save file known as 'story', it is likely with the file known as 'InteractiveFinal'.");
                            Console.WriteLine("Unfortunately, if that is the case, you will need to delete all local files and redownload the game.");

                            Console.ReadKey(true);
                            File.WriteAllText(story, pageNumber);
                            File.WriteAllText(story2, pageNumber);
                            GameOver = true;

                        }

                        Console.Clear();

                        DisplayScreen();

                        //saving the game
                        if (choice.KeyChar == '1')
                        {
                            Console.Beep();

                            pageNumber = currentPage.ToString();

                            File.WriteAllText(story, pageNumber);
                        }
                        else if (choice.KeyChar == '2')
                        {
                            Console.Beep();

                            pageNumber = currentPage.ToString();

                            File.WriteAllText(story2, pageNumber);
                        }
                        //not an ending
                        if (pageElements.Length > 1)
                        {
                            choice = Console.ReadKey(true);

                            if (choice.KeyChar == 'a' && pageElements.Length > 1)
                            {
                                Console.Beep();

                                currentPage = int.Parse(pageElements[3]);
                            }

                            else if (choice.KeyChar == 'b' && pageElements.Length > 1)
                            {
                                Console.Beep();

                                currentPage = int.Parse(pageElements[4]);
                            }

                            else if (choice.KeyChar == 'c' && pageElements.Length > 1)
                            {
                                Console.Beep();

                                GameOver = true;
                            }
                            
                            else if (choice.KeyChar == '1')
                            {
                                Console.Beep();

                                pageNumber = currentPage.ToString();

                                File.WriteAllText(story, pageNumber);
                            }
                            
                            else if (choice.KeyChar == '2')
                            {
                                Console.Beep();

                                pageNumber = currentPage.ToString();

                                File.WriteAllText(story2, pageNumber);
                            }

                            //if the player presses a wrong key it's not really a problem, but this will chastise them
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Oops! That key wasn't an option.");
                                Console.ReadKey(true);
                            }

                        }
                    }

                }

            }

            catch (FileNotFoundException)
            {
                pageNumber = currentPage.ToString();
                Console.WriteLine("There is no first save file. It has now been created. Press any key to close the game.");
                File.WriteAllText(story, pageNumber);
                Console.ReadKey(true);
                Console.Clear();
                GameOver=true;
            }
        }

        static void MainMenu(string story, string saveData)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("CAVE OF WISHES");

            Console.WriteLine();

            Console.WriteLine("NEW GAME: A");
            
            Console.WriteLine();

            Console.WriteLine("LOAD SAVE FILE 1: B");

            Console.WriteLine();

            Console.WriteLine("LOAD SAVE FILE 2: D");

            Console.WriteLine();

            Console.WriteLine("EXIT GAME: C");

            choice = Console.ReadKey(true);

            //start the game
            if (choice.KeyChar == 'a')
            {
                Console.Beep();
                Menu = false;
            }

            else if (choice.KeyChar == 'A')
            {
                Console.Beep();

                Menu = false;
            }

            //load game from a certain page
            else if (choice.KeyChar == 'b')
            {
                Console.Beep();

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

                    File.WriteAllText(story, pageNumber);

                    Console.Clear();

                }
                Menu = false;
            }

            else if (choice.KeyChar == 'B')
            {
                Console.Beep();

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

                    File.WriteAllText(story, pageNumber);

                    Console.Clear();

                }
                Menu = false;
            }
            
            //load save file 2
            else if (choice.KeyChar == 'd')
            {
                Console.Beep();

                string story2 = @"savegame2.txt";

                string saveData2 = File.ReadAllText(story2);

                try
                {
                    currentPage = int.Parse(saveData2);
                }
                catch
                {
                    Console.WriteLine("ERROR: The file has been tampered with. Computer will now explode.");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Not really, but please press any button to overwrite the file. You will unfortunately lose your progress and have to start from the beginning.");

                    Console.ReadKey(true);

                    pageNumber = currentPage.ToString();

                    File.WriteAllText(story2, pageNumber);

                    Console.Clear();

                }
                Menu = false;
            }

            else if (choice.KeyChar == 'D')
            {
                Console.Beep();
                
                string story2 = @"savegame2.txt";

                string saveData2 = File.ReadAllText(story2);


                try
                {
                    currentPage = int.Parse(saveData2);
                }
                catch
                {
                    Console.WriteLine("ERROR: The file has been tampered with. Computer will now explode.");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Not really, but please press any button to overwrite the file. You will unfortunately lose your progress and have to start from the beginning.");

                    Console.ReadKey(true);

                    pageNumber = currentPage.ToString();

                    File.WriteAllText(story2, pageNumber);

                    Console.Clear();

                }
                Menu = false;
            }

            //quit the game
            else if (choice.KeyChar == 'c')
            {
                Console.Beep();

                GameOver = true;
            }

            else if (choice.KeyChar == 'C')
            {
                Console.Beep();

                GameOver = true;
            }
            
            //if the player presses a wrong key it's not really a problem, but this will chastise them
            else
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Oops! That key wasn't an option.");
                Console.ReadKey(true);
                Console.Clear();
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
            Console.Write(" to save to save file 1. Press");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("2");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" to save to save file 2.");


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
                Console.WriteLine();
                
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
