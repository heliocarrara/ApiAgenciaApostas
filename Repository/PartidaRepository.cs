using System.Collections.Generic;
using System.Linq;
using AgenciaApostas.Data;
using Microsoft.EntityFrameworkCore;
using AgenciaApostas.Models;
using AgenciaApostas.ViewModels.ListViewModels;

namespace AgenciaApostas.Repositories
{
    public class PartidaRepository
    {
        private readonly StoreDataContext _context;

        public PartidaRepository(StoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<VMListPartidas> Get()
        {
            var todasPartidas = _context.Partidas.Where(x => x.ativo).ToList();

            var model = new List<VMListPartidas>();

            foreach (var cadaPartida in todasPartidas)
            {
                model.Add(new VMListPartidas(cadaPartida));
            }

            return model;
        }
        public Partida Get(int id)
        {
            return _context.Partidas.Find(id);
        }
        public void Save(Partida time)
        {
            _context.Partidas.Add(time);
            _context.SaveChanges();
        }
        public void Update(Time time)
        {
            _context.Entry<Time>(time).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}