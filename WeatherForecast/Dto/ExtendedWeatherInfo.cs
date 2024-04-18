namespace WeatherForecast.Dto;

public class ExtendedWeatherInfo : WeatherInfo
{
    public WeatherGeneralDescribtion Describtion { get; }
    private static readonly int itemsInEnum = Enum.GetNames(typeof(WeatherGeneralDescribtion)).Length;

    public ExtendedWeatherInfo(WeatherInfo info)
    {
        City = info.City;
        Hour = info.Hour;
        TemperatureC = info.TemperatureC;
        
        Describtion = (WeatherGeneralDescribtion)new Random().Next(0, itemsInEnum - 1);
    }
}