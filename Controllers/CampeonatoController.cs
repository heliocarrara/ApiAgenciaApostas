using AgenciaApostas.Data;
using AgenciaApostas.Models;
using AgenciaApostas.ViewModels;
using AgenciaApostas.ViewModels.ListViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgenciaApostas.Repository;

namespace AgenciaApostas.Controllers
{
    public class CampeonatoController : Controller
    {
        private readonly CampeonatoRepository _repository;

        public CampeonatoController(CampeonatoRepository repository)
        {
            _repository = repository;
        }

        [Route("v1/campeonatos")]
        [HttpGet]
        public IEnumerable<VMListCampeonato> Get()
        {
            var todosCampeonatos = _repository.Get().ToList();

            var model = new List<VMListCampeonato>();

            foreach (var cadaCampeonato in todosCampeonatos)
            {
                var partidas = _repository.GetPartidasByCampeonato(cadaCampeonato.id).ToList();

                model.Add(new VMListCampeonato(cadaCampeonato, partidas));
            }

            return model;
        }

        [Route("v1/campeonatos/{id}")]
        [HttpGet]
        public Campeonato Get(long id)
        {
            return _repository.Get(id);
        }

        [Route("v1/campeonatos")]
        [HttpPost]
        public void Save(Campeonato campeonato)
        {
            _repository.Save(campeonato);
        }

        [Route("v1/campeonatos")]
        [HttpPost]
        public void Update(Campeonato campeonato)
        {
            _repository.Update(campeonato);
        }
        public bool GerarGanhadores(Campeonato campeonato)
        {
            try
            {
                var time = new List<VMPontuacaoTime>();

                foreach (var cadaPartida in campeonato.Partidas.ToList())
                {
                    var time1 = time.FirstOrDefault(x => x.time_id == cadaPartida.time1_id);

                    if (time1 == null)
                    {
                        time.Add(new VMPontuacaoTime(cadaPartida.time1_id, cadaPartida.PontosTime1));
                    }
                    else
                    {
                        time1.Pontuacao += cadaPartida.PontosTime1;
                    }

                    var time2 = time.FirstOrDefault(x => x.time_id == cadaPartida.time1_id);

                    if (time2 == null)
                    {
                        time.Add(new VMPontuacaoTime(cadaPartida.time2_id, cadaPartida.PontosTime2));
                    }
                    else
                    {
                        time2.Pontuacao += cadaPartida.PontosTime1;
                    }
                }

                time = time.OrderByDescending(x => x.Pontuacao).ToList();

                campeonato.time_campeao_id = time[0].time_id;
                campeonato.time_vice_id = time[1].time_id;
                campeonato.time_terceiro_id = time[2].time_id;

                _repository.Update(campeonato);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
