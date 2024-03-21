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
       public Task<Turn> GetTurnByIdAsync(int id); 
        public void AddTurnAsync(Turn turn);
        public Task<Turn> PutTurnAsync(int id, Turn turn);
        public void DeleteTurnAsync(int id);
    }
}
