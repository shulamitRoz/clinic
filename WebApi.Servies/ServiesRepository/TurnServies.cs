using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Models;
using WebApi.Core.ServiesModeld;
using WebApi.Entities;

namespace WebApi.Servies.ServiesRepository
{
    public class TurnServies:ITurnServices
    {
        private readonly ITurn _turn;
        public TurnServies(ITurn turn)
        {
            _turn = turn;
        }

        public List<Turn> GetListTurns()
        {
            return _turn.Getallturns().ToList();
        }
        public async Task<Turn> GetTurnByIdAsync(int id)
        {

            if (id != -1)
            {
                return await _turn.GetTurnByIdAsync(id);
            }
            else return null;
        }
        public void AddTurnAsync(Turn turn)
        {
             _turn.AddTurnAsync(turn);
        }

        public async Task<Turn> PutTurnAsync(int id, Turn turn)
        {
            if (id != -1)        
            {
                return await _turn.PutTurnAsync(id, turn);
            }
            else return null;

        }
        public void DeleteTurnAsync(int id)
        {
            int index = _turn.Getallturns().ToList().FindIndex((Turn e) => e.Id == id);

            if (index != -1)
            {
                _turn.DeleteTurnAsync(index);

            }
        }

    }
}
