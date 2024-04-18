using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Dto;
using WeatherForecast.Infrastructure;
using WeatherForecast.Infrastructure.Interfaces;

namespace WeatherForecast.Controllers;

[ApiController]
[Route("[controller]")]
public class Task3Controller : ControllerBase
{
    private readonly ISensorsFactory _sensorsFactory;

    public Task3Controller(ISensorsFactory sensorsFactory)
    {
        _sensorsFactory = sensorsFactory;
    }

    [HttpGet("temp/all")]
    public double[] GetSensorsTemps()
    {
        // todo Добавить try catch для обработки ошибок/исключений
        return _sensorsFactory
            .GetAll()
            .Select(x => x.ValueC * 9.0 / 5.0 + 32.0)
            .ToArray();
    }

    [HttpGet("sensors/all")]
    public string[] GetSensorsIds()
    {
        // todo Добавить try catch для обработки ошибок/исключений
        return _sensorsFactory
            .GetAll()
            .Select(x => x.Id)
            .ToArray();
    }

    [HttpGet("sensors/{id}")]
    public SensorInfo GetSensor(string id)
    {
        // todo Добавить try catch для обработки ошибок/исключений
        if (string.IsNullOrEmpty(id))
            return SensorInfo.NotFound;

        var sensor = _sensorsFactory.GetSensor(id);

        if (sensor == null)
            return SensorInfo.NotFound;

        return new SensorInfo
        {
            Id = sensor.Id,
            ValueF = $"{sensor.ValueC * 9.0 / 5.0 + 32.0}"
        };
    }
}