using AgenciaApostas.Models;
using System;
using System.Collections.Generic;

namespace AgenciaApostas.ViewModels.ListViewModels
{
    public class VMListCampeonato
    {
        public long id { get; set; }
        public string nome { get; set; }
        public VMListTime vencedor { get; set; }
        public VMListTime vice { get; set; }
        public VMListTime terceiro { get; set; }
        public IEnumerable<VMListPartidas> partida { get; set; }
    }
}
