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
        public async Task<ActionResult> Get(int id)
        {
            var turn=await _iTurnServies.GetTurnByIdAsync(id);
            var newTurn=_mapper.Map<TurnDto>(turn);
            return Ok(newTurn);

        }
        [HttpPost]
        public void Post([FromBody] TurnDto newEvent)
        {
            var turnToAdd=_mapper.Map<Turn>(newEvent);     
            _iTurnServies.AddTurnAsync(turnToAdd); 
            //return _iTurnServies.GetListTurns()[_iTurnServies.GetListTurns().Count - 1];

        }
        [HttpPut("{id}")]
        public async Task< Turn >Put(int id, [FromBody] TurnDto updateEvent)
        {
            var turnToUpdate = _mapper.Map<Turn>(updateEvent);
            return await _iTurnServies.PutTurnAsync(id, turnToUpdate);
        }
        [HttpDelete("{id}")]
        public void Delete(int num)
        {
            _iTurnServies.DeleteTurnAsync(num);  
            
        }

    }

}


