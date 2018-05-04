using Newtonsoft.Json;
using System;
using System.Net;
using System.Xml.Serialization;

namespace AnotherService.Data
{
    [Serializable]
    public class City
    {
        public readonly string Name, Country;

        public City(string csvLine)
        {
            string[] input = csvLine.Split(",");
            this.Name = input[0];
            this.Country = input[5];
        }
    }

    public enum Weather
    {
        SUNNY, RAIN, OTHER
    }
}
