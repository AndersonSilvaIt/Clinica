using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    [Table("Cliente")]
    public class Cliente : EntidadeBase
    {
        public Cliente()
        {
            DataNascimento = (DateTime)SqlDateTime.MinValue;
        }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime DataNascimento { get ; set; }
        public string FoneResidencial { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string DataNascimentoToString {
            get 
            {
                if (this.DataNascimento < new DateTime(1900, 1, 1))
                    return "";
                return this.DataNascimento.ToString("dd/MM/yyyy");
            }
            set { }
        }

    }
}
