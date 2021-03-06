﻿using System;
using System.Runtime.CompilerServices;
using System.IO;

namespace M266A_Dutly
{
    internal class Program
    {
        //This creates a new game or you can choose to load a savegame
        public static void Main(string[] args)
        {
            America america = new America();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string title = System.IO.File.ReadAllText(@"C:\Users\vmadmin\RiderProjects\M266A_Dutly\assets\TitleScreen.txt");
            Console.Write(title);
            Console.WriteLine();
            Console.ResetColor();
            
            Console.WriteLine("Do you want to load a savegame? [y/n]");
            if (Console.ReadLine() == "y")
            {
                Console.WriteLine();
                LoadGame();
            }
            else
            {
                America.SetDifficulty();
                america.Start();
            }
        }
        //This method is for loading the Savegames. They are compatible with every version of the game
        public static void LoadGame()
        {
            Console.WriteLine("What savegame do you want to load? (Only type in the number)");

            PrintSaveGameNames();
            
            int saveSlot = Convert.ToInt32(Console.ReadLine());

            if (File.Exists(@"C:\Users\vmadmin\RiderProjects\M266A_Dutly\assets\SaveGames\SaveGame" + saveSlot +
                            ".txt"))
            {
                string[] items = new string[8];
                int counter = 0;

                System.IO.StreamReader file =
                    new System.IO.StreamReader(@"C:\Users\vmadmin\RiderProjects\M266A_Dutly\assets\SaveGames\SaveGame" +
                                               saveSlot + ".txt");
                while ((items[counter] = file.ReadLine()) != null)
                {
                    counter++;
                }
                file.Close();

                Console.ForegroundColor = ConsoleColor.Yellow;
                
                America america = new America();
                Resources resources = new Resources();
                resources.Money = Convert.ToInt32(items[0]);
                resources.Food = Convert.ToInt32(items[1]);
                resources.Medicine = Convert.ToInt32(items[2]);
                resources.Oxfood = Convert.ToInt32(items[3]);
                Oxen.OxCount = Convert.ToInt32(items[4]);
                People.PersonCount = Convert.ToInt32(items[5]);
                America.Difficulty = Convert.ToInt32(items[6]);
                Console.WriteLine("file loaded successfully!");
                Console.ResetColor();
                america.Start();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("This savegame doesn't exist");
            }
        }
        //This code just displays the Savegames
        public static void PrintSaveGameNames()
        {
            System.IO.DirectoryInfo ParentDirectory = new System.IO.DirectoryInfo(@"C:\Users\vmadmin\RiderProjects\M266A_Dutly\assets\SaveGames");

            foreach (System.IO.FileInfo f in ParentDirectory.GetFiles())
            {
                Console.WriteLine("Savefile: " + f.Name);
            }
        }
    }
}
//Never give a string on the menus or the game will crash

// Different things get displayed in different colors
// Default color: Menu
// Yellow: Information
// Cyan: Text
// Green: Positive Event
// Red: Negative event

//WARNING: The game doesn't tell you that you overwrite an existing savefile