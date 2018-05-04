using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AnotherService.Controllers
{
    public abstract class AbstractController : Controller
    {
        protected AbstractController()
        {
        }

        protected WebClient ForexClient(string token, string symbol)
        {
            WebClient client = new WebClient();
            client.QueryString.Add("_token", token);
            client.QueryString.Add("Symbol", symbol);
            return client;
        }

        protected WebClient GeodataClient(string token, string cityName, string mode, string country = null)
        {
            WebClient client = new WebClient();
            client.QueryString.Add("appid", token);
            client.QueryString.Add("q", country == null ? cityName : String.Format("{0},{1}", cityName, country));
            client.QueryString.Add("mode", mode);
            return client;
        }
    }
}
