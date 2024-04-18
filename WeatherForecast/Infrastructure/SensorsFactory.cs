using WeatherForecast.Infrastructure.Interfaces;

namespace WeatherForecast.Infrastructure;

public class SensorsFactory : ISensorsFactory
{
    private readonly Dictionary<string, ISensor> _sensorsCache =
        new Dictionary<string, ISensor>
        {
            { "052b", new Sensor("o52b") },
            { "9c67", new Sensor("9c67") },
            { "397e", new Sensor("397e") },
            { "e130", new Sensor("e130") },
            { "1a23", new Sensor("1a23") },
            { "7ca0", new Sensor("7cao") },
            { "7e96", new Sensor("7e96") },
            { "7183", new Sensor("7183") },
            { "68fc", new Sensor("68fc") },
            { "fc8a", new Sensor("fc8a") }
        };

    // todo добавить проверку на null для id
    public ISensor GetSensor(string id)
    {
        if (_sensorsCache.TryGetValue(id, out var sensor))
            return sensor;

        return null;
    }

    public ISensor[] GetAll()
    {
        return _sensorsCache.Values.ToArray();
    }
    // todo есть возможность добавить метод для добавления нового датчика
}