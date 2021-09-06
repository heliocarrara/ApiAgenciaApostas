using AgenciaApostas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaApostas.ViewModels.ListViewModels
{
    public class VMListPartida
    {
        public long id { get; set; }

        public int PontosTime1 { get; set; }
        public int PontosTime2 { get; set; }
        public string Placar { get; set; }
        public string Times { get; set; }
        public string Campeonato_nome { get; set; }

        public long time1_id { get; set; }
        public long time2_id { get; set; }
        public long campeonato_id { get; set; }
        

        public VMListPartida()
        {
        }

        public VMListPartida(Partida partida)
        {
            this.id = partida.id;
            this.time1_id = partida.time1_id;
            this.time2_id = partida.time2_id;
            this.PontosTime1 = partida.PontosTime1;
            this.PontosTime2 = partida.PontosTime2;

            this.campeonato_id = partida.campeonato_id;
            this.Campeonato_nome = partida.Campeonato.Nome;

            if (partida.PontosTime1 > partida.PontosTime2)
            {
                this.Times = partida.Time1.nome + " X " + partida.Time2.nome;

                this.Placar = partida.PontosTime1 + " X " + partida.PontosTime2;
            }
            else
            {
                this.Times = partida.Time2.nome + " X " + partida.Time1.nome;

                this.Placar = partida.PontosTime2 + " X " + partida.PontosTime1;
            }
        }

        
    }
}
