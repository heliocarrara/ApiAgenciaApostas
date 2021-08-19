using System.Collections.Generic;
using System.Linq;
using AgenciaApostas.Data;
using Microsoft.EntityFrameworkCore;
using AgenciaApostas.Models;

namespace AgenciaApostas.Repositories
{
    public class TimeRepository
    {
        private readonly StoreDataContext _context;

        public TimeRepository(StoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Time> Times Get()
        {
            return _context
                .Time
                .Select(x => new Time
                {
                    id = x.id,
                    nome = x.nome,
                })
                .AsNoTracking()
                .Where(x => x.ativo)
                .ToList();
        }
        public Time Get(int id)
        {
            return _context.Time.Find(id);
        }
        public void Save(Time time)
        {
            _context.Time.Add(time);
            _context.SaveChanges();
        }
        public void Update(Time time)
        {
            _context.Entry<Time>(time).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}