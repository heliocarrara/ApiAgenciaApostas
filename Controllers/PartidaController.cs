using AgenciaApostas.Repository;
using AgenciaApostas.ViewModels.ListViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgenciaApostas.Models;
using AgenciaApostas.ViewModels;

namespace AgenciaApostas.Controllers
{
    public class PartidaController: Controller
    {
        private readonly PartidaRepository _repository;

        public PartidaController(PartidaRepository repository)
        {
            _repository = repository;
        }

        [Route("v1/partidas")]
        [HttpGet]
        public IEnumerable<VMListPartida> Get()
        {
            return _repository.Get();
        }

        [Route("v1/partidas/{id}")]
        [HttpGet]
        public Partida Get(int id)
        {
            return _repository.Get(id);
        }

        [Route("v1/partidas")]
        [HttpPost]
        public VMResult Post([FromBody] VMListPartida model)
        {
            var partida = new Partida()
            {
                Ativo = true,
                campeonato_id = model.id,
                time1_id = model.time1_id,
                time2_id = model.time2_id,
                PontosTime1 = model.PontosTime1,
                PontosTime2 = model.PontosTime2,

            };

            _repository.Save(partida);

            return new VMResult
            {
                Success = true,
                Message = "Partida cadastrada com sucesso!",
                Data = partida
            };
        }

        [Route("v1/partidas")]
        [HttpPost]
        public VMResult Post([FromBody] Partida partida)
        {
            _repository.Save(partida);

            return new VMResult
            {
                Success = true,
                Message = "Partida cadastrada com sucesso!",
                Data = partida
            };
        }

        [Route("v1/partidas")]
        [HttpPut]
        public VMResult Put([FromBody] VMPartida model)
        {
            var partida = _repository.Get(model.id);

            partida.Ativo = model.Ativo;
            partida.campeonato_id = model.campeonato_id;
            partida.PontosTime1 = model.PontosTime1;
            partida.PontosTime2 = model.PontosTime2;
            partida.time1_id = model.time1_id;
            partida.time2_id = model.time2_id;

            _repository.Update(partida);

            return new VMResult
            {
                Success = true,
                Message = "Partida alterada com sucesso!",
                Data = partida
            };
        }

        [Route("v1/partidas/{id}")]
        [HttpDelete]
        public Partida Delete(long id)
        {
            var partida = _repository.Get(id);

            partida.Ativo = false;

            _repository.Update(partida);

            return partida;
        }

        
    }
}
