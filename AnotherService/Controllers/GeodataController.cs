using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using AnotherService.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace AnotherService.Controllers
{
    [Route("api/[controller]")]
    public class GeodataController : AbstractController
    {
        private const string ClearSky = "clear sky";
        private const string BadWeather = "bad weather";
        private readonly string CurrentWeatherRequestUrl = "http://api.openweathermap.org/data/2.5/weather";
        private readonly string TomorrowWeatherRequestUrl = "http://api.openweathermap.org/data/2.5/forecast";
        private readonly string YesterdayWeatherRequestUrl = "http://api.openweathermap.org/data/2.5/history/city";
        private readonly string Token = "fcd0cde9d01dfa6a93de28f65fd78718";
        private readonly string Xml = "xml";

        // GET api/geodata/weather/current
        [HttpGet]
        [Route("weather/current")]
        public string GetCityWeather(string CityName, string Country = null)
        {
            try
            {
                return XDocument.Parse(
                    GeodataClient(Token, CityName, Xml, Country)
                    .DownloadString(CurrentWeatherRequestUrl))
                    .Element("current")
                    .Element("weather")
                    .Attribute("value")
                    .Value;
            } catch (Exception e)
            {
                Debug.Print(e.Message);
            }
            return String.Format("failed to process {0}", CityName);
        }

        // GET api/geodata/weather/yesterday
        [HttpGet]
        [Route("weather/yesterday")]
        public string GetCityWeatherPrevDay(string CityName)
        {
            return "this api is not free :'(";
        }

        // GET api/geodata/weather/forecast
        [HttpGet]
        [Route("weather/forecast")]
        public string GetCityWeatherNextDays(string CityName, int DaysAhead = 1)
        {
            try
            {
                return ServiceManager.GeoDataService.IsRainPredicted(
                    XDocument.Parse(GeodataClient(Token, CityName, Xml)
                    .DownloadString(TomorrowWeatherRequestUrl))
                    .Element("weatherdata")
                    .Element("forecast")
                    .Elements("time"),
                    DaysAhead
                ) ? ClearSky : BadWeather;
            } catch (Exception e)
            {
                Debug.Print(e.Message);
            }
            return String.Format("failed to process {0}", CityName);
        }

        // GET api/geodata/city
        [HttpGet]
        [Route("city")]
        public City GetRandomCity()
        {
            return ServiceManager.GeoDataService.GetRandomCity();
        }

        // GET api/geodata/cities
        [HttpGet]
        [Route("cities")]
        public List<City> GetAllCities()
        {
            return ServiceManager.GeoDataService.GetAllCities();
        }

        // GET api/geodata/city
        [HttpGet]
        [Route("country")]
        public string GetRandomCountry()
        {
            return ServiceManager.GeoDataService.GetRandomCity().Country;
        }


        // GET api/geodata/calendar/weeks
        [HttpGet]
        [Route("calendar/weeks")]
        public int GetWeeksInYear(int year)
        {
            return ServiceManager.CalendarService.GetWeeksInYear(year);
        }
    }
}