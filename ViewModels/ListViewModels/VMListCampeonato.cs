using AgenciaApostas.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgenciaApostas.ViewModels.ListViewModels
{
    public class VMListCampeonato
    {
        #region CONSTRUCTORS
        public long id { get; set; }
        public string Nome { get; set; }
        public VMTime Vencedor { get; set; }
        public VMTime Vice { get; set; }
        public VMTime Terceiro { get; set; }
        public IEnumerable<VMListPartida> Partidas { get; set; }
        #endregion
        #region CONSTRUCTORS
        public VMListCampeonato()
        {

        }
        public VMListCampeonato(Campeonato campeonato, List<VMListPartida> partidas)
        {
            this.id = campeonato.id;
            this.Nome = campeonato.Nome;
            this.Partidas = partidas;
            this.Vencedor = new VMTime(campeonato.Campeao);
            this.Vice = new VMTime(campeonato.Vice); 
            this.Terceiro = new VMTime(campeonato.Terceiro);
        }

        public VMListCampeonato(VMListCampeonato cadaCampeonato, List<VMListPartida> partidas)
        {
            this.id = cadaCampeonato.id;
            this.Nome = cadaCampeonato.Nome;
            this.Partidas = partidas;
            this.Vencedor = cadaCampeonato.Vencedor;
            this.Vice = cadaCampeonato.Vice;
            this.Terceiro = cadaCampeonato.Terceiro;
        }
        #endregion
    }
}
