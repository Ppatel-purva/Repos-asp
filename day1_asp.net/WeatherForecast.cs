namespace day1_asp.net
{
    public class WeatherForecast
    {
        public DateTime firstname { get; set; }

        public int lastname { get; set; }

        public int TemperatureF => 32 + (int)(lastname / 0.5556);

        public string? Summary { get; set; }
    }
}