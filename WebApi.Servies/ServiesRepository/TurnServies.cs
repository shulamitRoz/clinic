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
        public Turn GetTurnById(int id)
        {

            if (id != -1)
            {
                return _turn.GetTurnById(id);
            }
            else return null;
        }
        public void AddTurn(Turn turn)
        {
             _turn.AddTurn(turn);
        }

        public Turn UpDate(int id, Turn turn)
        {
            if (id != -1)        
            {
                return _turn.PutTurn(id, turn);
            }
            else return null;

        }
        public void DeleteTurn(int id)
        {
            int index = _turn.Getallturns().ToList().FindIndex((Turn e) => e.Id == id);

            if (index != -1)
            {
                _turn.DeleteTurn(index);

            }
        }

    }
}
