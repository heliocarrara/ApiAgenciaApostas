using AgenciaApostas.Repositories;
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
    public class PartidaController
    {
        private readonly PartidaRepository _repository;

        public PartidaController(PartidaRepository repository)
        {
            _repository = repository;
        }

        [Route("v1/partidas")]
        [HttpGet]
        public IEnumerable<VMListPartidas> Get()
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
        public VMResult Post([FromBody] VMListPartidas model)
        {
            model.Validate();
            if (model.Invalid)
                return new VMResult
                {
                    Success = false,
                    Message = "Não foi possível cadastrar o produto",
                    Data = model.Notifications
                };

            var partida = new Partida();
            partida.id = model.id;
            partida.ativo = true;
            partida.campeonato_id = model.campeonato_id; // Nunca recebe esta informação
            partida.time1_id = model.Partida.time1_id;
            partida.time2_id = model.Partida.time2_id;
            partida.pontosTime1 = model.Partida.pontosTime1;
            partida.pontosTime2 = model.Partida.pontosTime2;

            _repository.Save(partida);

            return new VMResult
            {
                Success = true,
                Message = "Produto cadastrado com sucesso!",
                Data = partida
            };
        }

        [Route("v2/partidas")]
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
            model.Validate();
            if (model.Invalid)
                return new VMResult
                {
                    Success = false,
                    Message = "Não foi possível alterar o produto",
                    Data = model.Notifications
                };

            var partida = _repository.Get(model.Id);
            partida.ativo = model.Title;
            partida.CategoryId = model.CategoryId;
            // product.CreateDate = DateTime.Now; // Nunca altera a data de criação

            _repository.Update(partida);

            return new VMResult
            {
                Success = true,
                Message = "Partida alterado com sucesso!",
                Data = partida
            };
        }
    }
}
