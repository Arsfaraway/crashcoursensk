namespace WeatherForecast.Constants;

// todo ���� ����������� ��������� �������� � ���� ������������ json
public class Constants
{

    // todo WellKnownCities �� ������ ���������� �������� - ����� ���� �� ������������� �����������
    public static string[] WellKnownCities = { "Novosibirsk", "Tomsk", "Moscow", "Krasnodar" };
    // todo WellKnownMethods �� ������ ���������� �������� - ����� ���� �� ������������� �����������
    public static string[] WellKnownMethods = { "min", "max", "avg" };
    // todo GenerateCount �� ������ ���������� �������� - ����� ������������� ����������� (��������������� ���������� ����? �� �������)
    public const int GenerateCount = (int)10e5;

    // todo Task2ControllerCity �� ���������� ���, ��� � �������� �������� ������, ������� � �.�. � ������ �������� - �����������.
    // todo ���� �� �������� �� ������ �������, ���������������� ��� ���������� �������, �� ��������� ��, �� �������� ��� �� �����
    // todo �������� ������������, � ���������� �������� ������� ����� ��������
    public const string Task2ControllerCity = "Novosibirsk";
    public const string CoffeeMessage = "Use this promocode to buy coffee from our partners with a 10% discount";
}