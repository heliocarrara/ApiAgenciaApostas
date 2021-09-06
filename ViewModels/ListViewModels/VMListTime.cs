using AgenciaApostas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaApostas.ViewModels.ListViewModels
{
    public class VMListTime
    {
        #region PROPERTIES
        public long id { get; set; }
        public string Nome { get; set; }
        #endregion

        #region 
        public VMListTime()
        {

        }

        public VMListTime(Time time)
        {
            this.Nome = time.nome;
            this.id = time.id;
        }
        #endregion

    }
}
