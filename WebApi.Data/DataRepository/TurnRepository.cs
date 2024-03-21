using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Models;
using WebApi.Entities;

namespace WebApi.Data.DataRepository
{
    public class TurnRepository : ITurn
    {
        private readonly DataContext _turnData;

        public TurnRepository(DataContext turnData)
        {
            _turnData = turnData;
        }
        public IEnumerable<Turn> Getallturns()
        {
            return _turnData.turnes.Include(d => d.Doctor);

        }
        public async Task<Turn> GetTurnByIdAsync(int id)
        {
           return _turnData.turnes.ToList().Find(e => e.Id == id);
          await  _turnData.SaveChangesAsync();
        }
        public async void AddTurnAsync(Turn turn)
        {
           _turnData.turnes.Add(turn);
           await _turnData.SaveChangesAsync();

        }
        public async Task<Turn> PutTurnAsync(int id, Turn turn)

        {
            int index = _turnData.turnes.ToList().FindIndex((Turn e) => e.Id == id);

            _turnData.turnes.ToList()[index].DateTurn = DateTime.Now;
            _turnData.turnes.ToList()[index].Title = turn.Title;
            _turnData.turnes.ToList()[index].TypeOfDoctor = turn.TypeOfDoctor;
            return _turnData.turnes.ToList()[index];
            await _turnData.SaveChangesAsync();
        }
        public async void DeleteTurnAsync(int index)
        {
            _turnData.turnes.Remove(_turnData.turnes.ToList()[index]);
           await _turnData.SaveChangesAsync();
        }
    }
}
