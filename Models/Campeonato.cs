using System;
using System.Collections.Generic;

namespace AgenciaApostas.Models
{
    public class Campeonato
    {
        public long id { get; set; }
        public bool ativa { get; set; }
        public string nome { get; set; }
        public IEnumerable<Partida> partidas { get; set;}
        public Time campeao { get; set; }
        public Time vice { get; set; }
        public Time terceiro { get; set; }
    }
}
