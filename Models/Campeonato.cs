using System;
using System.Collections.Generic;

namespace AgenciaApostas.Models
{
    public class Campeonato
    {
        public long id { get; set; }
        public bool Ativa { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Partida> Partidas { get; set;}
        public Time Campeao { get; set; }
        public long time_campeao_id { get; set; }
        public Time Vice { get; set; }
        public long time_vice_id { get; set; }
        public Time Terceiro { get; set; }
        public long time_terceiro_id { get; set; }
    }
}
