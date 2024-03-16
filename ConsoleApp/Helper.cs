using DotNetEnv;

public static class Helper
{
    public static void PrintMenu()
    {
        Console.Clear(); //Clear the screen before writing to it
        Console.WriteLine("════════════════════════════════════════");
        Console.WriteLine("         Joskin Meteo and News           ");
        Console.WriteLine("════════════════════════════════════════");
    }

    public static void PrintMenuOptions(string[] menuOptions)
    {
        for (int i = 0; i < menuOptions.Length; i++) //This will go through a list of string and prit it to the screen
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
                catch (Exception) //here we catch the exception but as we do not use it we don't write a name like "ex"
                {
                    Console.WriteLine("Format error, please enter a number.");
                }
            }
        } while (selection < 1 || selection > max);
        return selection;
    }

    public static async Task GetWeather(string cityName) //this is async as we use async values and every async function returns task.
    {

        Env.Load(); // this is a package used to store sensible information

        string? apiKey = Environment.GetEnvironmentVariable("API_KEY");

        if (apiKey == null)
            throw new IOException(); //if we can't open the file to get the api key

        string countryName = "BE";

        string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={cityName},{countryName}&appid={apiKey}&units=metric";


        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode(); // if country not found

            string responseBody = await response.Content.ReadAsStringAsync();

            dynamic? weatherData = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody);

            if (weatherData != null)
            {
                Helper.PrintMenu();
                Console.WriteLine($"Weather in {weatherData.name}, {weatherData.sys.country}:");
                Console.WriteLine($"Description: {weatherData.weather[0].description}");
                Console.WriteLine($"Temperature: {weatherData.main.temp} °C");
                Console.WriteLine($"Humidity: {weatherData.main.humidity}%");
                Console.Write("Press enter to continue.");
                Console.ReadLine();
            }

        }

    }
}
