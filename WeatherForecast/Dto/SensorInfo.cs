using System.Text.Json.Serialization;

namespace WeatherForecast.Dto;

public class SensorInfo
{
    [JsonPropertyName("id")]
    public string Id;
    
    public string ValueF;

    public static SensorInfo NotFound => new SensorInfo
    {
        Id = "<unknown>",
        ValueF = null
    };
}