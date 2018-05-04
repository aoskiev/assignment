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
    public class PersonController : AbstractController
    {
        // GET api/person/random
        [HttpGet]
        [Route("random")]
        public Person GetRandomPerson()
        {
            return ServiceManager.PersonService.GetRandomPerson();
        }

        // GET api/person/all
        [HttpGet]
        [Route("all")]
        public List<Person> FindAllPersons()
        {
            return ServiceManager.PersonService.GetAllClients();
        }

        // GET api/person/search
        [HttpGet]
        [Route("search")]
        public Person FindByNameSurname(string Name, string Surname)
        {
            return ServiceManager.PersonService.FindPersonByName(Name, Surname);
        }
    }
}
