using AgenciaApostas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaApostas.ViewModels
{
    public class VMCampeonato
    {
        public long id { get; set; }
        public bool ativa { get; set; }
        public string nome { get; set; }

        public Time ganhador { get; set; }
        public Time vice { get; set; }
        public Time terceiro { get; set; }
    }
}
