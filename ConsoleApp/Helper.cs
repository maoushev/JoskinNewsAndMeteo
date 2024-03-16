using DotNetEnv;
using System.ServiceModel.Syndication;
using System.Xml;

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

    public static async Task GetWeatherAsync(string cityName) //this is async as we use async values and every async function returns task.
    {

        Env.Load(); // this is a package used to store sensible information

        string? apiKey = Environment.GetEnvironmentVariable("API_KEY");

        if (apiKey == null)
            throw new IOException(".env file cannot be opened."); //if we can't open the file to get the api key

        string countryName = "BE";

        string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={cityName},{countryName}&appid={apiKey}&units=metric";


        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode(); // if country not found this throws an error

            string responseBody = await response.Content.ReadAsStringAsync(); //gets the useful content from the response of the api call

            dynamic? weatherData = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody); //get's us a usable object that we can easily use.

            if (weatherData == null)
                throw new Exception("Weather Api not responding.");

            Console.WriteLine($"Weather in {weatherData.name}, {weatherData.sys.country}:");
            Console.WriteLine($"Description: {weatherData.weather[0].description}");
            Console.WriteLine($"Temperature: {weatherData.main.temp} °C");
            Console.WriteLine($"Humidity: {weatherData.main.humidity}%");
            Helper.WriteMessageAndWait("Press enter to continue.");

        }

    }

    public static async Task GetNewsAsync(int news)
    {
        string rssFeed;
        if (news == 1)
            rssFeed = "https://feeds.bbci.co.uk/news/world/rss.xml";
        else
            rssFeed = "http://rss.cnn.com/rss/edition_world.rss";

        using (HttpClient client = new HttpClient())
        {
            string rssContent = await client.GetStringAsync(rssFeed); //get's a string with the content of the rss feed
            var xmlReader = XmlReader.Create(new System.IO.StringReader(rssContent)); //This creates a cml reader from the string that we got earlier.
            SyndicationFeed feed = SyndicationFeed.Load(xmlReader); //This read the data fom the reader and parses it to a SyndicationFeed object

            if (feed == null)
                throw new Exception("RSS feed cannot be read."); //if there is an error and the object is not set

            if (news == 1)
                Console.WriteLine("Latest News from BBC");
            else
                Console.WriteLine("Latest News from CNN");

            int count = 0;
            foreach (SyndicationItem item in feed.Items)
            {
                Console.WriteLine("════════════════════════════════════════");
                Console.WriteLine("News N°" + (count + 1) + " | Published Date: " + item.PublishDate.DateTime);
                Console.WriteLine("Title: " + item.Title.Text);
                Console.WriteLine("Link: " + item.Links[0].Uri.ToString());
                count++;
                if (count >= 5)
                    break;
            }
            Helper.WriteMessageAndWait("Press enter to continue.");
        }
    }

    public static void WriteMessageAndWait(string mess)
    {
        Console.Write(mess);
        Console.ReadLine();
    }

    public static async Task ChoiceMeteoAsync()
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
        Helper.PrintMenu();
        await Helper.GetWeatherAsync(city);
    }

    public static async Task ChoiceNewsAsync()
    {
        int selection;
        string[] newsOption = { "BBC", "CNN" };
        Helper.PrintMenu();
        Helper.PrintMenuOptions(newsOption);
        selection = Helper.GetUserChoice(2);
        Helper.PrintMenu();
        await Helper.GetNewsAsync(selection);
    }
}

