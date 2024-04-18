using System;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Infrastructure.Interfaces;

namespace WeatherForecast.Controllers;

[ApiController]
[Route("[controller]/statistics")]
public class Task1Controller : ControllerBase
{
    private readonly IWeatherInfoProvider _weatherInfoProvider;

    public Task1Controller(IWeatherInfoProvider weatherInfoProvider)
    {
        _weatherInfoProvider = weatherInfoProvider;
    }

    [HttpGet("calc")]
    public string[] CalculateStatistics(string city, string method)
    {
        // todo Две проверки на null не нужны, т.к. методы уже учитывают null (32 и 44 строки)
        if (city != null && !CheckCity(city))
            return new[] { $"City '{city}' is invalid." };

        if (method != null && !CheckMethod(method))
            return new[] { $"Method '{method}' is invalid." };

        var data = _weatherInfoProvider.GetDataForLast12Hours(Constants.Constants.GenerateCount);

        var query = city != null ? data.Where(w => w.City.Equals(city, StringComparison.OrdinalIgnoreCase)) : data;

        var results = query
        .GroupBy(w => new { City = w.City, Hour = w.Hour })
        .Select(group => new
        {
            City = group.Key.City,
            Hour = group.Key.Hour,
            Temperatures = method switch
            {
                "min" => group.Min(w => w.TemperatureC),
                "max" => group.Max(w => w.TemperatureC),
                _ => group.Average(w => w.TemperatureC)
            }
        })
        .OrderBy(result => result.City)
        .ThenBy(result => result.Hour)
        .Select(w => $"{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(w.City.ToLower())}, h: {w.Hour}, {w.Temperatures:F2} °C")
        .ToArray();

        return results;
    }

    [HttpGet("delta")]
    public double CalculateDelta(string city)
    {
        if (!CheckCity(city))
            return -404.0;

        var data = _weatherInfoProvider.GetDataForLast12Hours(Constants.Constants.GenerateCount);

        var cityData = data.Where(w => w.City.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();

        if (!cityData.Any())
            return -505.0;

        var deltas = cityData.GroupBy(w => w.Hour)
                              .Select(group => group.Average(w => w.TemperatureC))
                              .ToList();

        if (deltas.Count < 2)
            return -606.0;

        return Math.Abs(deltas.Max() - deltas.Min());
    }

    // todo Все тело метода CheckCity можно записать в одну строчку через LINQ, что повышает читаемость кода
    // todo Помимо этого, если заменить список на HashSet, то производительность повысится, объем кода сократится
    private bool CheckCity(string city)
    {
        foreach (var validCity in Constants.Constants.WellKnownCities)
        {
            if (string.Equals(validCity, city, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    // todo все тело метода CheckMethod можно аналогично записать через LINQ с использованием HashSet
    private bool CheckMethod(string method)
    {
        foreach (var validMethod in Constants.Constants.WellKnownMethods)
        {
            if (string.Equals(validMethod, method, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }
}