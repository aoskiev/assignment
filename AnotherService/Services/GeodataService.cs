using AnotherService.Data;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using System.Collections;

namespace AnotherService.Controllers
{
    public class GeodataService
    {
        public static readonly List<City> Cities = new List<City>();

        public GeodataService()
        {
            PreloadCities();
        }

        public void PreloadCities()
        {
            if (Cities.Count < 10)
            {
                Cities.AddRange(File.ReadLines("Resources/cities.csv").Select(line => new City(line)).Skip(1).ToList());
            }
        }

        public City GetRandomCity()
        {
            PreloadCities();
            return Cities.ElementAt(new Random(DateTime.Now.Millisecond).Next(0, Cities.Count - 1));
        }

        public bool IsRainPredicted(IEnumerable<XElement> elements, int days)
        {
            IEnumerator enumerator = elements.GetEnumerator();
            while (enumerator.MoveNext())
            {
                DateTime fromDate;
                DateTime untilDate;
                XElement currentElement = (XElement)enumerator.Current;

                DateTime.TryParse(currentElement
                    .Attribute("from")
                    .Value,
                    out fromDate);

                DateTime.TryParse(currentElement
                     .Attribute("to")
                     .Value,
                     out untilDate);

                if (fromDate.DayOfYear > DateTime.Now.DayOfYear
                    && untilDate.DayOfYear < DateTime.Now.AddDays(days + 1).DayOfYear)
                {
                    return currentElement.Element("symbol").Attribute("name").Value.Contains("clear");
                }
                if (fromDate.DayOfYear >= DateTime.Now.AddDays(days + 1).DayOfYear)
                {
                    return false;
                }
            }
            return false;
        }

        public List<City> GetAllCities()
        {
            return Cities;
        }
    }
}