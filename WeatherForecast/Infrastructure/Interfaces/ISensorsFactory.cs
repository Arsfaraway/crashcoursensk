namespace WeatherForecast.Infrastructure.Interfaces;

public interface ISensorsFactory
{
    // todo: нужен комментарий, описывающий назначение интерфейса
    // todo: есть возможность добавить еще методы для более обширной работы
    public ISensor GetSensor(string id);
    public ISensor[] GetAll();
}