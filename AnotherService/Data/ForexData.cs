using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnotherService.Data
{
    [Serializable]
    public class ForexRateDto
    {
        private string Spread;
        private string Ask;
        private double _mid;
        private string Bid;
        private string Delay;
        private string Outcome;
        private string Source;
        private string Text;
        private string QuoteType;
        private string Time;
        private string Date;
        private string Symbol;
        private string QuoteCurrency;
        private string BaseCurrency;
        private string Identity;
        private string Message;

        public double Mid { get => _mid; set => _mid = value; }
    }
}
