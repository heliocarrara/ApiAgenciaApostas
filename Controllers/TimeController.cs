using AgenciaApostas.Models;
using AgenciaApostas.Repository;
using AgenciaApostas.ViewModels;
using AgenciaApostas.ViewModels.ListViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgenciaApostas.Controllers
{
    public class TimeController : Controller
    {
        private readonly TimeRepository _repository;

        public TimeController(TimeRepository repository)
        {
            _repository = repository;
        }

        [Route("v1/times")]
        [HttpGet]
        public IEnumerable<VMListTime> Get()
        {
            return _repository.Get();
        }

        [Route("v1/times/{id}")]
        [HttpGet]
        public Time Get(int id)
        {
            return _repository.Get(id);
        }

        [Route("v1/times")]
        [HttpPost]
        public VMResult Post([FromBody] VMListTime model)
        {
            var time = new Time()
            {
                ativo = true,
                id = model.id,
                nome = model.Nome
            };

            _repository.Save(time);

            return new VMResult
            {
                Success = true,
                Message = "Time cadastrado com sucesso!",
                Data = time
            };
        }

        [Route("v1/times")]
        [HttpPost]
        public VMResult Post([FromBody] Time time)
        {
            _repository.Save(time);

            return new VMResult
            {
                Success = true,
                Message = "Time cadastrado com sucesso!",
                Data = time
            };
        }

        [Route("v1/times")]
        [HttpPut]
        public VMResult Put([FromBody] VMTime model)
        {
            var time = _repository.Get(model.id);

            time.ativo = model.ativo;
            time.nome = model.nome;

            _repository.Update(time);

            return new VMResult
            {
                Success = true,
                Message = "Time alterado com sucesso!",
                Data = time
            };
        }


        [Route("v1/times/{id}")]
        [HttpDelete]
        public Time Delete(long id)
        {
            var time = _repository.Get(id);

            time.ativo = false;

            _repository.Update(time);

            return time;
        }

        public List<Partida> GerarPartidas(long campeonato_id)
        {
            var partidas = new List<Partida>();
            var times = _repository.Get().ToList();
            var random = new Random();

            for (int i = 0; i < times.Count; i ++)
            {
                for (int j = (times.Count- 1); j >= 0; j--)
                {
                    bool primeiroCaso = partidas.Any(x => x.time1_id == times[i].id && x.time2_id == times[j].id);
                    bool segundoCaso = !primeiroCaso ? partidas.Any(x => x.time1_id == times[j].id && x.time2_id == times[i].id) : false;

                    if (primeiroCaso)
                    {
                        partidas.Add(new Partida
                        {
                            campeonato_id = campeonato_id,
                            time1_id = times[i].id,
                            time2_id = times[j].id,
                            PontosTime1 = random.Next(0, 7),
                            PontosTime2 = random.Next(0, 7)
                        });
                    }
                    else if (segundoCaso)
                    {
                        partidas.Add(new Partida
                        {
                            campeonato_id = campeonato_id,
                            time1_id = times[j].id,
                            time2_id = times[i].id,
                            PontosTime1 = random.Next(0, 7),
                            PontosTime2 = random.Next(0, 7)
                        });
                    }
                }
            }

            return partidas;
        }
    }
}
