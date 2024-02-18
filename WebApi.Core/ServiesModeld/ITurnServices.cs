using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Core.ServiesModeld
{
    public interface ITurnServices
    {
        public List<Turn> GetListTurns();
       public Turn GetTurnById(int id); 
        public void AddTurn(Turn turn);
        public Turn PutTurn(int id, Turn turn);
        public void DeleteTurn(int id);
    }
}
