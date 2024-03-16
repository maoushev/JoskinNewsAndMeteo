using System;
using System.ComponentModel.Design;

public static class Helper
{
    public static void PrintMenu()
    {
        Console.Clear();
        Console.WriteLine("════════════════════════════════════════");
        Console.WriteLine("         Joskin Meteo and News           ");
        Console.WriteLine("════════════════════════════════════════");
    }

    public static void PrintMenuOptions(string[] menuOptions)
    {
        for (int i = 0; i < menuOptions.Length; i++)
        {
            Console.WriteLine($"               {i + 1}. {menuOptions[i]}");
        }
        Console.WriteLine("════════════════════════════════════════");
        Console.WriteLine();
    }

    public static int GetUserChoice(int max)
    {
        int selection = 0;
        do
        {
            string? choice = Console.ReadLine();
            if (choice != null)
            {
                try
                {
                    selection = int.Parse(choice);
                }
                catch (Exception)
                {
                    Console.WriteLine("Format error, please enter a number.");
                }
            }
        } while (selection < 1 || selection > max);
        return selection;
    }
}