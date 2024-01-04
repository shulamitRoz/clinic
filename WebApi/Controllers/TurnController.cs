using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnController : ControllerBase
    
    {
            private static List<Turn> turns = new List<Turn>
        {
            new Turn {TurnNumber=1,DateTurn=DateTime.Today,Title="Blood Test"},
            new Turn {TurnNumber=2,DateTurn=DateTime.Now,Title="flu shot"},
            new Turn {TurnNumber=3,DateTurn=DateTime.Today,Title="doctor's checkup"},
        };
            [HttpGet]
            public IEnumerable<Turn> Get()
            {
                return turns;

            }
            [HttpGet("{id}")]
            public ActionResult Get(DateTime date)
            {

                var isIDExists = turns.Find(e => e.DateTurn == date);
                if (isIDExists == null)
                    return NotFound();
                else
                    return Ok(isIDExists);
            }
            [HttpPost]
            public Turn Post([FromBody] Turn newEvent)
            {
                turns.Add(new Turn { TurnNumber = 789, DateTurn = newEvent.DateTurn, Title = newEvent.Title });

                return turns[turns.Count - 1];
            }
            [HttpPut("{id}")]
            public Turn Put(int num, [FromBody] Turn updateEvent)
            {
                int index = turns.FindIndex((Turn e) => { return e.TurnNumber == num; });
                turns[index].TurnNumber = updateEvent.TurnNumber;
                turns[index].DateTurn =DateTime.Now;
                turns[index].Title = updateEvent.Title;
                return updateEvent;
            }
            [HttpDelete("{id}")]
            public ActionResult Delete(int num)
            {

                var isIDExists = turns.Find(e => e.TurnNumber == num);
                if (isIDExists == null)
                    return NotFound();
                else
                    return Ok(isIDExists);

                int index = turns.FindIndex((Turn e) => { return e.TurnNumber == num; });
                turns.RemoveAt(index);
            }

        }

    }

}
}
