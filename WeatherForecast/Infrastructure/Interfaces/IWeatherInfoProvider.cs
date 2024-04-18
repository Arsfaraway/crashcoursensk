using WeatherForecast.Dto;

namespace WeatherForecast.Infrastructure.Interfaces;

public interface IWeatherInfoProvider
{
    // todo �� ������ ��� ��������� ������ � ���������� � �������
    // todo ���� ����������� ���������� ������� ��� ������ ���������� �������
    WeatherInfo[] GetDataForLast12Hours(int count);
    WeatherInfo GetDailyData(DateTime now, string city);
    ExtendedWeatherInfo GetExtendedDailyData(DateTime now, string city);
    List<WeatherInfo> Get10DaysData(DateTime now, string city);
}