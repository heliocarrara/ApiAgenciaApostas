using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaApostas.Models
{
    public class Partida
    {
        public long id { get; set; }
        public bool ativo { get; set; }
        public int pontosTime1 { get; set; }
        public int pontosTime2 { get; set; }

        public Time time1 { get; set; }
        public Time time2 { get; set; }
        public Campeonato campeonato { get; set; }


        public long campeonato_id { get; set; }
        public long time1_id { get; set; }
        public long time2_id { get; set; }

    }
}
