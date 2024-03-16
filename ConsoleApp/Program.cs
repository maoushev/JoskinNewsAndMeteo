using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int selection = 0;
            while (true)
            {
                string[] menuOptions = { "Meteo", "News", "Both", "Exit" };
                Helper.PrintMenu();
                Helper.PrintMenuOptions(menuOptions);

                selection = Helper.GetUserChoice(4);

                switch (selection)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }


            }

        }
    }
}