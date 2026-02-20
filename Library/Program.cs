using System;
using System.Globalization;

namespace Library;

class Program
{
    static void Main(string[] args)
    {
        // Translated the authors to English
        string[,] books =
        {
            {"Pushkin", "Lermontov", "Tolstoy" },
            {"Keyes", "Murakami", "Sapkowski"},
            {"Lovecraft", "Takemura", "Tyutchev"}
        };
        bool isOpen = true;

        while (isOpen)
        {
            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Full list of authors: ");
            for (int i = 0; i < books.GetLength(0); i++)
            {
                for (int j = 0; j < books.GetLength(1); j++)
                {
                    Console.Write(books[i, j] + " / ");
                }
                Console.WriteLine(); 
            }
            
            Console.SetCursorPosition(0,0);
            Console.WriteLine("Welcome to our library!");
            Console.WriteLine("Choose a search option: \n1 - Find author by location\n2 - Find location by author\n3 - Exit program ");
            Console.Write("Your choice: ");
            
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    int line, column;
                    Console.Write("Enter the shelf number: ");
                    line = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Write("Enter the spot number: ");
                    column = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.WriteLine("Your author is: " + books[line, column]);
                    break;
                case 2:
                    string author;
                    bool guessed = false;
                    Console.Write("Please write the author's name: ");
                    // Added .ToLower() here to make the search case-insensitive
                    author = Console.ReadLine().ToLower(); 
                    
                    for (int i = 0; i < books.GetLength(0); i++)
                    {
                        for (int j = 0; j < books.GetLength(1); j++)
                        {
                            if (author == books[i, j].ToLower())
                            {
                                Console.WriteLine($"Your author is: {books[i, j]}, located on shelf {i + 1}, spot {j + 1}");
                                guessed = true;
                            }
                        }
                    }
                    if (guessed == false)
                    {
                        Console.WriteLine("There is no such author.");
                    }
                    break;
                case 3:
                    isOpen = false;
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }

            if (isOpen)
            {
                Console.WriteLine("\nPress any key to continue...");
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}