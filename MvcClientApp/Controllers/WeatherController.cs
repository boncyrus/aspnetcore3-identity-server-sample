using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcClientApp.Models;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MvcClientApp.Controllers
{
    [Authorize]
    public class WeatherController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _apiClient;

        public WeatherController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _apiClient = _httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _apiClient.GetAsync("WeatherForecast");
            var jsonString = await response.Content.ReadAsStringAsync();
            var vm = new WeatherIndexViewModel()
            {
                WeatherData = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(jsonString)
            };

            return View(vm);
        }
    }
}