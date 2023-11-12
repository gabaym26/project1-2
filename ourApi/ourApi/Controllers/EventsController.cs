using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ourApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        public static int count = 1;
       public static List<Event> events = new List<Event> { new Event { Id =count++, Title = "default event1",Start=DateTime.Now },
         new Event { Id = count++, Title = "default event2",Start=DateTime.Now }
        , new Event { Id = count++, Title = "default event3",Start=DateTime.Now } };
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> GetAllEvents()
        {
            return events;
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event newEvent)
        {
            events.Add(new Event { Id = newEvent.Id, Title = newEvent.Title, Start = newEvent.Start,End=newEvent.End });
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event newEvent)
        {
            var eve = events.Find(e => e.Id == id);
            eve.Start = newEvent.Start;
            eve.End = newEvent.End;
            eve.Title = newEvent.Title;
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eve = events.Find(e => e.Id == id);
            events.Remove(eve);
        }
    }
}
