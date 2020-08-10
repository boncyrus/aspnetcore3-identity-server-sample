using System.Collections.Generic;
using System.Linq;

namespace MvcClientApp.Models
{
    public class WeatherIndexViewModel
    {
        public IEnumerable<WeatherForecast> WeatherData { get; set; } = Enumerable.Empty<WeatherForecast>();
    }
}