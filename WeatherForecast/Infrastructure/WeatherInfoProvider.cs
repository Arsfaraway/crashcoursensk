using WeatherForecast.Dto;
using WeatherForecast.Extensions;
using WeatherForecast.Infrastructure.Interfaces;

namespace WeatherForecast.Infrastructure;

public class WeatherInfoProvider : IWeatherInfoProvider
{
    private readonly Random _random = new();

    public WeatherInfo[] GetDataForLast12Hours(int count)
    {
        // todo нужна проверка, что count больше нуля
        var resultData = new WeatherInfo[count];

        var dataIndex = 0;
        var cityIndex = 0;
        var basicHour = DateTime.Now.Hour;
        var hour = basicHour;

        while (dataIndex < count)
        {
            var city = Constants.Constants.WellKnownCities[cityIndex % Constants.Constants.WellKnownCities.Length];
            // todo нужна проверка, что city не является null
            var dataItem = new WeatherInfo
            {
                City = city,
                Hour = hour,
                TemperatureC = _random.NextDouble(-30, 30)
            };

            resultData[dataIndex] = dataItem;

            dataIndex++;
            cityIndex++;

            if (dataIndex % Constants.Constants.WellKnownCities.Length == 0)
            {
                hour = basicHour - _random.Next(0, 12);
            }
        }

        return resultData;
    }

    public List<WeatherInfo> Get10DaysData(DateTime date, string city)
    {
        // todo нужна проверка, что city не является null
        // todo нужна проверка для date
        var resultData = new List<WeatherInfo>();

        for (var i = 0; i < 10; i++)
        {
            resultData.Add(GetDailyData(date, city));
            date = date.AddDays(1);
        }

        return resultData;
    }
    
    public WeatherInfo GetDailyData(DateTime date, string city)
    {
        // todo нужна проверка, что city не является null
        // todo нужна проверка для date
        var dataItem = new WeatherInfo
        {
            City = city,
            Hour = date.Hour,
            TemperatureC = _random.NextDouble(-30, 30)
        };
        return dataItem;
    }

    public ExtendedWeatherInfo GetExtendedDailyData(DateTime date, string city)
    {
        // todo нужна проверка, что city не является null
        // todo нужна проверка для date
        var daily = GetDailyData(date, city);
        var dataItem = new ExtendedWeatherInfo(daily);
        
        return dataItem;
    }
}