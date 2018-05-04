using AnotherService.Services;

namespace AnotherService.Controllers
{
    public static class ServiceManager
    {
        public static GeodataService GeoDataService = new GeodataService();
        public static PersonService PersonService = new PersonService();
        public static CalendarService CalendarService = new CalendarService();
    }
}
