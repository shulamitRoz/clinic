using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Core.DTO;
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
        private readonly IMapper _mapper;
        public TurnController (ITurnServices context,IMapper mapper)
        {
            _iTurnServies = context;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<Turn> Get()
        {
            var list =_iTurnServies.GetListTurns();
            var newList=_mapper.Map<IEnumerable<TurnDto>>(list);
            return Ok(newList);

        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var turn=_iTurnServies.GetTurnById(id);
            var newTurn=_mapper.Map<TurnDto>(turn);
            return Ok(newTurn);

        }
        [HttpPost]
        public void Post([FromBody] TurnDto newEvent)
        {
            var turnToAdd=_mapper.Map<Turn>(newEvent);     
            _iTurnServies.AddTurn(turnToAdd); 
            //return _iTurnServies.GetListTurns()[_iTurnServies.GetListTurns().Count - 1];

        }
        [HttpPut("{id}")]
        public Turn Put(int id, [FromBody] TurnDto updateEvent)
        {
            var turnToUpdate = _mapper.Map<Turn>(updateEvent);
            return _iTurnServies.UpDate(id, turnToUpdate);
        }
        [HttpDelete("{id}")]
        public void Delete(int num)
        {
            _iTurnServies.DeleteTurn(num);  
            
        }

    }

}


