using AnotherService.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace AnotherService.Data
{
    [Serializable]
    public class Person
    {
        public int id;
        public string Gender;
        public string Name;
        public string Surname;
        public string Phone;
        public string Email;
        public string Address;
        public string City;
        public string BirthCountry;
        public DateTime Birth;
        public string MaritalStatus;
        public string Nationality;
        public string Currency;
        public double GrossIncome;

        internal Person Random(int id)
        {
            this.id = id;
            this.Gender = GetRandomGender();
            this.MaritalStatus = GetRandomMarital();
            this.Name = GenerateRandomLineFromFile("Resources/first_names.csv");
            this.Surname = GenerateRandomLineFromFile("Resources/last_names.csv");
            this.Phone = GetRandomPhone();
            this.Email = GetRandomMail();
            this.Address = GenerateRandomLineFromFile("Resources/Street_Names.csv");
            this.City = ServiceManager.GeoDataService.GetRandomCity().Name;
            this.BirthCountry = ServiceManager.GeoDataService.GetRandomCity().Country;
            this.Nationality = ServiceManager.GeoDataService.GetRandomCity().Country;
            this.Birth = GetRandomBitrhDate();
            this.Currency = GenerateRandomLineFromFile("Resources/currencies.csv");
            this.GrossIncome = new Random().NextDouble() * 1000000;
            return this;
        }

        private DateTime GetRandomBitrhDate()
        {
            DateTime start = new DateTime(1970, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(new Random().Next(range));
        }

        private string GetRandomGender()
        {
            return PickRandomString("male", "female");
        }

        private string GetRandomMarital()
        {
            return PickRandomString("married", "not married");
        }

        private string GetRandomPhone()
        {
            StringBuilder builder = new StringBuilder("+");
            for (int i = 0; i < 12; i++)
            {
                builder.Append(new Random().Next(0, 9));
            }
            return builder.ToString();
        }

        private string GetRandomMail()
        {
            return String.Format("{0}.{1}@zmail.com", Name, Surname);
        }

        private string GenerateRandomLineFromFile(string FileName)
        {
            var lines = File.ReadAllLines(FileName);
            return lines[new Random().Next(0, lines.Length - 1)];
        }

        private string PickRandomString(string optionOne, string optionTwo)
        {
            if (new Random().NextDouble() > 0.5d)
            {
                return optionOne;
            }
            else
            {
                return optionTwo;
            }
        }
    }
}
