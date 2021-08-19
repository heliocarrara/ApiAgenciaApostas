using System.Collections.Generic;
using System.Linq;
using AgenciaApostas.Data;
using Microsoft.EntityFrameworkCore;
using AgenciaApostas.Models;
using AgenciaApostas.ViewModels.ListViewModels;

namespace AgenciaApostas.Repositories
{
    public class TimeRepository
    {
        private readonly StoreDataContext _context;

        public TimeRepository(StoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<VMListTime> Get()
        {
            var todosTimes = _context.Times.Where(x => x.ativo).ToList();

            var model = new List<VMListTime>();

            foreach (var cadaTime in todosTimes)
            {
                model.Add(new VMListTime(cadaTime));
            }

            return model;
        }
        public Time Get(int id)
        {
            return _context.Times.Find(id);
        }
        public void Save(Time time)
        {
            _context.Times.Add(time);
            _context.SaveChanges();
        }
        public void Update(Time time)
        {
            _context.Entry<Time>(time).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}