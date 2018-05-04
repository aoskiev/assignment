using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AnotherService.Data;
using Microsoft.AspNetCore.Mvc;

namespace AnotherService.Controllers
{
    [Route("api/[controller]")]
    public class ForexController : AbstractController
    {
        private const string GetRealtimeRateURL = "http://globalcurrencies.xignite.com/xGlobalCurrencies.json/GetRealTimeRate";
        private const string Token = "2C24EAAD6BB346188BED1292C480E855";
        private const string CURRENCY = "EUR";

        // GET api/forex/rates
        [HttpGet]
        [Route("rates")]
        public double GetRateForCurrencies(string currencies, string token)
        {
            ForexRateDto dto = Newtonsoft.Json.JsonConvert.DeserializeObject<ForexRateDto>(
                ForexClient(token == null? Token : token, currencies).DownloadString(GetRealtimeRateURL));
            return dto.Mid;
        }

        // GET api/forex/income
        [HttpGet]
        [Route("income")]
        public double GetWeeklyIncome(int PersonId)
        {
            Person person = ServiceManager.PersonService.FindPersonById(PersonId);
            double totalIncome = person.GrossIncome * GetRateForCurrencies(person.Currency + CURRENCY, Token);
            return totalIncome / ServiceManager.CalendarService.GetWeeksInYear(DateTime.Now.Year);
        }
    }
}
