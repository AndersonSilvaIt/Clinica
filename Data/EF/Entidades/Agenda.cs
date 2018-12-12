using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
   [Table("Agenda")]
    public class Agenda : EntidadeBase
    {

        public int IdPaciente { get; set; }
        public string PacienteNome { get; set; }
        public DateTime Data { get; set; }
        public string Horas { get; set; }
        public string Tipo { get; set; }
        public string Observacao { get; set; }
        public decimal Valor { get; set; }
        public string HorasToString {
            get {
                //if (//this.Horas > DateTime.MinValue)
                    //return this.Horas.ToString("HH:mm");

                return string.Empty;
            }
            set { }
        }

        public string DataToString {
            get {
                if (this.Data > DateTime.MinValue)
                    return this.Data.ToString("dd/MM/yyyy");

                return string.Empty;
            }
            set { }
        }

        public string Situation { get; set; }
    }
}
