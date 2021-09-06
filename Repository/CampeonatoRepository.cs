using AgenciaApostas.Data;
using AgenciaApostas.Models;
using AgenciaApostas.ViewModels.ListViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaApostas.Repository
{
    public class CampeonatoRepository
    {
        private readonly StoreDataContext _context;

        public CampeonatoRepository(StoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<VMListCampeonato> Get()
        {
            var todosCampeonatos = _context.Campeonatos.Where(x => x.Ativa).ToList();

            var model = new List<VMListCampeonato>();

            foreach (var cadaCampeonato in todosCampeonatos)
            {
                model.Add(new VMListCampeonato(cadaCampeonato, GetPartidasByCampeonato(cadaCampeonato.id).ToList()));
            }

            return model;
        }
        public Campeonato Get(long id)
        {
            var model = _context.Campeonatos.Find(id);
            model.Campeao = _context.Times.Find(model.time_campeao_id);
            model.Vice = _context.Times.Find(model.time_vice_id);
            model.Terceiro = _context.Times.Find(model.time_terceiro_id);

            return model;
        }
        public void Save(Campeonato campeonato)
        {
            _context.Campeonatos.Add(campeonato);
            _context.SaveChanges();
        }
        public void Update(Campeonato campeonato)
        {
            _context.Entry<Campeonato>(campeonato).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public IEnumerable<VMListPartida> GetPartidasByCampeonato(long campeonato_id)
        {
            var todasPartidas = _context.Partidas.Where(x => x.Ativo && x.campeonato_id == campeonato_id).ToList();

            var model = new List<VMListPartida>();

            foreach (var cadaPartida in todasPartidas)
            {
                model.Add(new VMListPartida(cadaPartida));
            }

            return model;
        }
    }
}
