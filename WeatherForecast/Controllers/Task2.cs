using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Infrastructure.Interfaces;

namespace WeatherForecast.Controllers;

[ApiController]
[Route("[controller]/nsk")]
public class Task2Controller : ControllerBase
{
    private readonly IWeatherInfoProvider _weatherInfoProvider;
    private readonly string _city;

    public Task2Controller(IWeatherInfoProvider weatherInfoProvider)
    {
        _weatherInfoProvider = weatherInfoProvider;
        _city = Constants.Constants.Task2ControllerCity;
    }

    [Route("daily")]
    public IActionResult GetDailyForecast()
    {  
        // todo не совсем корректно использовать DateTime.Now напрямую, лучше использовать его как аргумент по умолчанию
        // todo у пользователя нет возможности указать дату, передав ее в метод
        var result = _weatherInfoProvider.GetDailyData(DateTime.Now, _city);
        // todo как вариант: добавить проверку result
        return new JsonResult(result);
    }

    [Route("extendedDaily")]
    public IActionResult GetExtendedDailyForecast()
    {
        // todo аналогично GetDailyForecast()
        var result = _weatherInfoProvider.GetExtendedDailyData(DateTime.Now, _city);
        // todo как вариант: добавить проверку result
        return new JsonResult(result);
    }

    [Route("10Days")]
    public IActionResult Get10DaysForecast()
    {
        // todo аналогично GetDailyForecast()
        var result = _weatherInfoProvider.Get10DaysData(DateTime.Now, _city);
        // todo как вариант: добавить проверку result
        return new JsonResult(result);
    }
}