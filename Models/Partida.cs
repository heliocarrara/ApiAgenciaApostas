using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaApostas.Models
{
    public class Partida
    {
        public long id { get; set; }
        public bool Ativo { get; set; }
        public int PontosTime1 { get; set; }
        public int PontosTime2 { get; set; }

        public Time Time1 { get; set; }
        public Time Time2 { get; set; }
        public Campeonato Campeonato { get; set; }


        public long campeonato_id { get; set; }
        public long time1_id { get; set; }
        public long time2_id { get; set; }

    }
}
