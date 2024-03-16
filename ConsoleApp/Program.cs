namespace ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int selection = 0;

            while (true) //infinite loop
            {
                string[] menuOptions = { "Meteo", "News", "Both", "Exit" };
                Helper.PrintMenu();
                Helper.PrintMenuOptions(menuOptions);

                selection = Helper.GetUserChoice(4);

                switch (selection)
                {
                    case 1:
                        try
                        {
                            string? city = null;
                            Helper.PrintMenu();
                            Console.Write("Please input a city : ");
                            do
                            {
                                city = Console.ReadLine();
                                if (city == null)
                                    Console.WriteLine("Please input a string.");
                            } while (city == null);


                            await Helper.GetWeather(city);
                        }
                        catch (HttpRequestException) //If the api can't find the city
                        {
                            Console.Write("City not found.Press enter to continue");
                            Console.ReadLine();
                        }
                        catch (IOException) // if the .env file cannot be opened
                        {
                            Console.Write("An error occured.Press enter to continue");
                            Console.ReadLine();
                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }


            }

        }
    }
}