namespace ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int selection;

            Log.Initialize("log.log");

            while (true) //infinite loop
            {
                string[] menuOptions = { "Meteo", "News", "Both", "Exit" };
                Helper.PrintMenu();
                Helper.PrintMenuOptions(menuOptions);

                selection = Helper.GetUserChoice(4);

                try
                {
                    switch (selection)
                    {
                        case 1:
                            await Helper.ChoiceMeteoAsync();
                            break;
                        case 2:
                            await Helper.ChoiceNewsAsync();
                            break;
                        case 3:
                            await Helper.ChoiceMeteoAsync();
                            await Helper.ChoiceNewsAsync();
                            break;
                        case 4:
                            Log.CloseAndFlush();
                            Environment.Exit(0);
                            break;
                    }
                }
                catch (HttpRequestException ex) //If the api can't find the city
                {
                    ErrorHandler.HandleError("City not found.", ex);
                }
                catch (IOException ex) // if the .env file cannot be opened
                {
                    ErrorHandler.HandleError("An error occured.Please try again.", ex);
                }
                catch (ArgumentNullException ex)
                {
                    ErrorHandler.HandleError("An error occured.Please try again.", ex);
                    Log.Error(ex.Message);
                }
                catch (Exception ex)
                {
                    ErrorHandler.HandleError("An error occured.Please try again.", ex);
                }
            }

        }
    }
}