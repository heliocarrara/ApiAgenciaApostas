using System.Collections.Generic;
using System.Linq;
using AgenciaApostas.Data;
using Microsoft.EntityFrameworkCore;
using AgenciaApostas.Models;
using AgenciaApostas.ViewModels.ListViewModels;

namespace AgenciaApostas.Repository
{
    public class PartidaRepository
    {
        private readonly StoreDataContext _context;

        public PartidaRepository(StoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<VMListPartida> Get()
        {
            var todasPartidas = _context.Partidas.Where(x => x.Ativo).ToList();

            var model = new List<VMListPartida>();

            foreach (var cadaPartida in todasPartidas)
            {
                model.Add(new VMListPartida(cadaPartida));
            }

            return model;
        }
        public Partida Get(long id)
        {
            return _context.Partidas.Find(id);
        }
        public void Save(Partida partida)
        {
            _context.Partidas.Add(partida);
            _context.SaveChanges();
        }
        public void Update(Partida partida)
        {
            _context.Entry<Partida>(partida).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}