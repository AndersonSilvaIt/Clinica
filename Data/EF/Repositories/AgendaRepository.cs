using Data.EF.Interfaces;
using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.EF.Repositories
{
    public class AgendaRepository : BaseRepostiry<Agenda>, IAgenda
    {
        public IList<Agenda> SearchAgenda(string paciente, string dtInicial,string dtFim, string horaInicial, string horaFinal, string servico, string situacao)
        {
            using (Context ctx = new Context())
            {
                var a = ctx.Agenda.AsQueryable();

                if (!string.IsNullOrWhiteSpace(paciente.Trim()))
                {
                    a = a.Where(p => p.PacienteNome.Contains(paciente)).OrderBy(p => p.PacienteNome).ThenBy(p => p.Data).ThenBy(p => p.Horas);
                }

                if(!string.IsNullOrWhiteSpace(dtInicial) && string.IsNullOrWhiteSpace(dtInicial))
                {
                    DateTime inicialDate;
                    DateTime finalDate;
                    if(DateTime.TryParse(dtInicial, out inicialDate) && DateTime.TryParse(dtFim, out finalDate))
                    {
                        a = a.Where(p => p.Data >= inicialDate && p.Data <= finalDate).OrderBy(p => p.PacienteNome).ThenBy(p => p.Data).ThenBy(p => p.Horas);

                    }
                }
                else if (!string.IsNullOrWhiteSpace(dtInicial.Trim()))
                {
                    DateTime inicialDate;
                    if (DateTime.TryParse(dtInicial, out inicialDate))
                    {
                        a = a.Where(p => p.Data == inicialDate).OrderBy(p => p.PacienteNome).ThenBy(p => p.Data).ThenBy(p => p.Horas); ;
                    }
                }
                else if (!string.IsNullOrWhiteSpace(dtFim.Trim()))
                {
                    DateTime finalDate;
                    if (DateTime.TryParse(dtFim, out finalDate))
                    {
                        a = a.Where(p => p.Data == finalDate).OrderBy(p => p.PacienteNome).ThenBy(p => p.Data).ThenBy(p => p.Horas); ;
                    }
                }

                if (!string.IsNullOrWhiteSpace(horaInicial) && !string.IsNullOrWhiteSpace(horaFinal))
                {
                    DateTime inicialDate;
                    DateTime finalDate;
                    if (DateTime.TryParse(horaInicial, out inicialDate) && DateTime.TryParse(horaFinal, out finalDate))
                    {
                        //a = a.Where(p => p.Horas >= inicialDate && p.Horas <= finalDate).OrderBy(p => p.PacienteNome).ThenBy(p => p.Data).ThenBy(p => p.Horas); ;
                    }
                }
                else if (!string.IsNullOrWhiteSpace(horaInicial.Trim()))
                {
                    DateTime inicialDate;
                    if (DateTime.TryParse(horaInicial, out inicialDate))
                    {
                        //a = a.Where(p => p.Horas == inicialDate).OrderBy(p => p.PacienteNome).ThenBy(p => p.Data).ThenBy(p => p.Horas); ;
                    }
                }
                else if (!string.IsNullOrWhiteSpace(horaFinal.Trim()))
                {
                    DateTime finalDate;
                    if (DateTime.TryParse(horaFinal, out finalDate))
                    {
                        //a = a.Where(p => p.Horas == finalDate).OrderBy(p => p.PacienteNome).ThenBy(p => p.Data).ThenBy(p => p.Horas); ;
                    }
                }

                if (!string.IsNullOrWhiteSpace(servico.Trim()))
                {
                    a = a.Where(p => p.Tipo == servico).OrderBy(p => p.PacienteNome).ThenBy(p => p.Data).ThenBy(p => p.Horas);
                }

                if (!string.IsNullOrWhiteSpace(situacao.Trim()))
                {
                    a = a.Where(p => p.Situation == situacao).OrderBy(p => p.PacienteNome).ThenBy(p => p.Data).ThenBy(p => p.Horas);
                }

                return a.ToList();
            }
        }

        public Agenda GetAgenda(DateTime dtInicial, DateTime horaInicial, long id)
        {
            string data = dtInicial.ToString("dd/MM/yyyy");
            string hora = horaInicial.ToString("HH:mm");
            using (var ctx = new Context())
            {
                if(id > 0)
                    return ctx.Agenda.FirstOrDefault(p => p.DataToString == data && p.HorasToString == hora && p.Id != id);               
                else
                    return ctx.Agenda.FirstOrDefault(p => p.DataToString == data && p.HorasToString == hora);
            }
        }

    }
}
