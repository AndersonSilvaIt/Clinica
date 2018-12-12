using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF.Entidades
{
    public class AgendaReportAux
    {
        public string PacienteNome { get; set; }
        public DateTime Data { get; set; }
        public string Horas { get; set; }
        public string Tipo { get; set; }
        public string Observacao { get; set; }
        public decimal Valor { get; set; }
        public string Situation { get; set; }

        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public string FoneResidencial { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

    }
}
