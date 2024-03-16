# Joskin News :newspaper: and Meteo :partly_sunny:

## Weather and News Console Application

This is a quick project developed for an interview at **[Joskin](https://www.joskin.com/fr "Joskin Website")** Soumagne. The application retrieves weather data from OpenWeatherMap API and displays it alongside the latest news articles fetched from an RSS feed.

This project uses the OpenWeatherMap API and needs an API KEY to work.

You need to create a .env file at the root of the project and add API_KEY={your-api-key}.


---

### Instructions (translated version):

1. **Web API (Weather Data):**
   - Utilize the OpenWeatherMap API or any other API of your choice to fetch weather data for a specified city.
   - Prompt the user to input the name of a city for which they want to obtain weather forecasts.
   - Display relevant weather data in the console, such as temperature, weather description, humidity, etc.

2. **RSS Feed (Articles):**
   - Utilize the SyndicationFeed class to read an RSS feed from a news source of your choice (e.g., BBC, CNN, etc.).
   - Display the titles and links of the latest available articles in the RSS feed.

3. **User Interface:**
   - Create a menu in the console allowing the user to choose whether they want to display weather data, news articles, or both.
   - If the user chooses to see both, first display the weather data, followed by the news articles.

---

### Consignes (version originale):

1. **API Web (Données météorologiques) :**
   - Utilisez l'API OpenWeatherMap ou toute autre API de votre choix pour obtenir les données météorologiques d'une ville spécifiée.
   - Demandez à l'utilisateur de saisir le nom d'une ville pour laquelle il souhaite obtenir les prévisions météorologiques.
   - Affichez les données météorologiques pertinentes dans la console, telles que la température, la description de la météo, l'humidité, etc.

2. **Flux RSS (Articles) :**
   - Utilisez la classe SyndicationFeed pour lire un flux RSS à partir d'une source d'actualités de votre choix (par exemple, BBC, CNN, etc.).
   - Affichez les titres et les liens des derniers articles disponibles dans le flux RSS.

3. **Interface utilisateur :**
   - Créez un menu dans la console permettant à l'utilisateur de choisir s'il souhaite afficher les données météorologiques, les articles du flux RSS, ou les deux.
   - Si l'utilisateur choisit de voir les deux, affichez d'abord les données météorologiques, suivies des articles du flux RSS.
