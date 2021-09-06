using AgenciaApostas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaApostas.ViewModels
{
    public class VMPontuacaoTime
    {
        public long time_id { get; set; }
        public int Pontuacao { get; set; }

        public VMPontuacaoTime()
        {
        }
        public VMPontuacaoTime(long time_id, int pontuacao)
        {
            this.time_id = time_id;
            Pontuacao = pontuacao;
        }
    }
}
