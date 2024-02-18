using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Core.Models
{
    public interface ITurn
    {
        public  IEnumerable<Turn> Getallturns();
        public Turn GetTurnById(int id);
        public void AddTurn(Turn turn);
        public Turn PutTurn(int id, Turn turn);
        public void DeleteTurn(int id);

    }
}
