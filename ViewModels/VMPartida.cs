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
        public bool ativo { get; set; }
        public string time1 { get; set; }
        public string time2 { get; set; }
        public int pontosTime1 { get; set; }
        public int pontosTime2 { get; set; }
        public long campeonato_id { get; set; }

        public VMPartida(Partida partida)
        {
            this.id = partida.id;
            this.time1 = partida.time1.nome;
            this.time2 = partida.time2.nome;
            this.pontosTime1 = partida.pontosTime1;
            this.pontosTime2 = partida.pontosTime2;
            this.campeonato_id = partida.campeonato_id;
            this.ativo = partida.ativo;
        }
    }
}
