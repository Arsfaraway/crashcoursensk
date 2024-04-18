namespace WeatherForecast.Infrastructure.Interfaces;

public interface ISensor
{
    // todo нужен комментарий, описывающий назначение интерфейса
    // todo есть возможность добавления дополнительной информации
    public string Id { get; }
    public double ValueC { get; }
}