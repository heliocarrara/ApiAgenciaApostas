using System.Collections.Generic;
using System.Linq;
using AgenciaApostas.Data;
using Microsoft.EntityFrameworkCore;
using AgenciaApostas.Models;

namespace AgenciaApostas.Repositories
{
    public class PartidaRepository
    {
        private readonly StoreDataContext _context;

        public PartidaRepository(StoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Partida> Partidas Get()
        {
            return _context
                .Partida
                .Include(x => x.time1)
                .Include(x => x.time2)
                .Select(x => new Time
                {
                    id = x.id,
                    nome = x.,
                })
                .AsNoTracking()
                .Where(x => x.ativo)
                .ToList();
        }
        public Partida Get(int id)
        {
            return _context.Partida.Find(id);
        }
        public void Save(Partida partida)
        {
            _context.Partida.Add(partida);
            _context.SaveChanges();
        }
        public void Update(Partida partida)
        {
            _context.Entry<Partida>(partida).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}