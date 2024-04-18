using WeatherForecast.Dto;

namespace WeatherForecast.Infrastructure.Interfaces;

public interface IWeatherInfoProvider
{
    // todo не забыть про обработку ошибок и исключений в методах
    // todo есть возможность добавления методов для разных интервалах времени
    WeatherInfo[] GetDataForLast12Hours(int count);
    WeatherInfo GetDailyData(DateTime now, string city);
    ExtendedWeatherInfo GetExtendedDailyData(DateTime now, string city);
    List<WeatherInfo> Get10DaysData(DateTime now, string city);
}