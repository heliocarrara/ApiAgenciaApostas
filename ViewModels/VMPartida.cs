using AgenciaApostas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaApostas.ViewModels
{
    public class VMPartida
    {
        public long id { get; set; }
        public bool Ativo { get; set; }
        public long time1_id { get; set; }
        public long time2_id { get; set; }
        public int PontosTime1 { get; set; }
        public int PontosTime2 { get; set; }
        public long campeonato_id { get; set; }

        public VMPartida(Partida partida)
        {
            this.id = partida.id;
            this.time1_id = partida.time1_id;
            this.time2_id = partida.time2_id;
            this.PontosTime1 = partida.PontosTime1;
            this.PontosTime2 = partida.PontosTime2;
            this.campeonato_id = partida.campeonato_id;
            this.Ativo = partida.Ativo;
        }
    }
}
