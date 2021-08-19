using AgenciaApostas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaApostas.ViewModels.ListViewModels
{
    public class VMListPartidas
    {
        public long id { get; set; }
        public Partida Partida { get; set; }
        public string Placar { get; set; }
        public string Times { get; set; }
        public long campeonato_id { get; set; }
        public string campeonato_nome { get; set; }

        public VMListPartidas()
        {
        }

        public VMListPartidas(Partida partida)
        {
            this.id = partida.id;
            this.Partida = partida;

            this.campeonato_id = partida.campeonato_id;
            this.campeonato_nome = partida.campeonato.nome;

            if (partida.pontosTime1 > partida.pontosTime2)
            {
                this.Times = partida.time1.nome + " X " + partida.time2.nome;

                this.Placar = partida.pontosTime1 + " X " + partida.pontosTime2;
            }
            else
            {
                this.Times = partida.time2.nome + " X " + partida.time1.nome;

                this.Placar = partida.pontosTime2 + " X " + partida.pontosTime1;
            }
        }

        
    }
}
