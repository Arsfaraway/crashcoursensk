using WeatherForecast.Infrastructure.Interfaces;

namespace WeatherForecast.Infrastructure;

public class Sensor : ISensor
{
    // todo есть возможность добавления дополнительной информации
    // todo можно добавить проверку на null или пустую строку для параметра id в конструкторе
    public Sensor(string id)
    {
        Id = id;
    }

    public string Id { get; }
    public double ValueF => (-50.0 + Random.Shared.NextDouble() * 100.0) * 9.0 / 5.0 + 32.0;
    public double ValueC => -50.0 + Random.Shared.NextDouble() * 100.0;
}