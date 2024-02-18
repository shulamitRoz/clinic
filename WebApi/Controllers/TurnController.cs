using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Core.ServiesModeld;
using WebApi.Entities;
using WebApi.Servies.ServiesRepository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnController : ControllerBase

    {
        //private static List<Turn> turns = new List<Turn>
        //{
        //    new Turn {TurnNumber=1,DateTurn=DateTime.Today,Title="Blood Test" ,TypeOfDoctor="doctor of children"},
        //    new Turn {TurnNumber=2,DateTurn=DateTime.Now,Title="flu shot",TypeOfDoctor="doctor of children"},
        //    new Turn {TurnNumber=3,DateTurn=DateTime.Today,Title="doctor's checkup",TypeOfDoctor="doctor of children"},
        //};
        private readonly ITurnServices _iTurnServies;

        public TurnController (ITurnServices context)
        {
            _iTurnServies = context;
        }
        [HttpGet]
        public IEnumerable<Turn> Get()
        {
            return _iTurnServies.GetListTurns();

        }
        [HttpGet("{id}")]
        public Turn Get(int id)
        {
            return _iTurnServies.GetTurnById(id);

        }
        [HttpPost]
        public void Post([FromBody] Turn newEvent)
        {
             _iTurnServies.AddTurn(newEvent); 
            //return _iTurnServies.GetListTurns()[_iTurnServies.GetListTurns().Count - 1];

        }
        [HttpPut("{id}")]
        public Turn Put(int num, [FromBody] Turn updateEvent)
        {
            return _iTurnServies.PutTurn(num, updateEvent);
        }
        [HttpDelete("{id}")]
        public void Delete(int num)
        {
            _iTurnServies.DeleteTurn(num);  
            
        }

    }

}


