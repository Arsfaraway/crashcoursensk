namespace WeatherForecast.Constants;

// todo есть возможность вынесени€ констант в файл конфигурации json
public class Constants
{

    // todo WellKnownCities не совсем корректное название - нужен хот€ бы по€снительный комментарий
    public static string[] WellKnownCities = { "Novosibirsk", "Tomsk", "Moscow", "Krasnodar" };
    // todo WellKnownMethods не совсем корректное название - нужен хот€ бы по€снительный комментарий
    public static string[] WellKnownMethods = { "min", "max", "avg" };
    // todo GenerateCount не совсем корректное название - нужен по€снительный комментарий (сгенерированное количество чего? Ќе пон€тно)
    public const int GenerateCount = (int)10e5;

    // todo Task2ControllerCity не корректное им€, как и подобные названи€ файлов, методов и т.д. ¬ рамках проектов - недопустимо.
    // todo ≈сли же исходить их логики проекта, предназначенного дл€ выполнени€ заданий, то впринципе ок, но название все же нужно
    // todo уточнить комментарием, и желательно название сделать более пон€тным
    public const string Task2ControllerCity = "Novosibirsk";
    public const string CoffeeMessage = "Use this promocode to buy coffee from our partners with a 10% discount";
}