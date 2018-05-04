using AnotherService.Data;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace AnotherService.Controllers
{
    public class PersonService
    {
        public List<Person> Persons = new List<Person>();

        private Random randomizer = new Random(DateTime.Now.Millisecond);

        public PersonService()
        {
            PreloadClients();
        }

        public int GetPersonId(string Name, string Surname)
        {
            Person result = Persons
                .Where(person => person.Name == Name)
                .Where(person => person.Surname == Surname)
                .First();
            return result.id;
        }

        public Person FindPersonById(int id)
        {
            try
            {
                Person result = Persons
                    .Where(person => person.id == id)
                    .First();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Person FindPersonByName(string Name, string Surname)
        {
            try
            {
                Person result = Persons
                    .Where(person => person.Name == Name)
                    .Where(person => person.Surname == Surname)
                    .First();
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Person> GetAllClients()
        {
            return Persons;
        }

        public Person GetRandomPerson()
        {
            int index = new Random().Next(0, Persons.Count - 1);
            return Persons[index];
        }

        private void PreloadClients()
        {
            while (Persons.Count < 15)
            {
                Persons.Add(new Person().Random(Persons.Count));
            }
        }
    }
}
