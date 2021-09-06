using AgenciaApostas.Models;

namespace AgenciaApostas.ViewModels
{
    public class VMTime
    {
        #region PROPERTIES
        public long id { get; set; }
        public bool ativo { get; set; }
        public string nome { get; set; }
        #endregion

        #region CONSTRUCTORS
        public VMTime(Time time)
        {
            this.id = time.id;
            this.ativo = time.ativo;
            this.nome = time.nome; 
        }
        #endregion
    }
}