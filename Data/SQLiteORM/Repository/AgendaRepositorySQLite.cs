using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Reflection;
using System.Text;

namespace Data.SQLiteORM.Repository
{
    public class AgendaRepositorySQLite : BaseRepository<Agenda>
    {
        public IList<Agenda> SearchAgenda(string paciente, string dtInicial, string dtFim, string horaInicial, string horaFinal, string servico, string situacao)
        {
            Banco _banco = new Banco();
            string strSQL = GetStringSQL(paciente, dtInicial, dtFim, horaInicial, horaFinal, servico, situacao);
            IList<Agenda> ListAgenda = new List<Agenda>();

            using (var cmd = _banco.DbConnection())
            {
                var obj = new Agenda();
                SQLiteCommand comand = new SQLiteCommand(strSQL);
                comand.Connection = cmd;
                PropertyInfo[] properties = obj.GetType().GetProperties();

                using (var reader = comand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        obj = Activator.CreateInstance<Agenda>();
                        foreach (PropertyInfo item in properties)
                        {
                            switch (item.PropertyType.Name)
                            {
                                case "String":
                                    item.SetValue(obj, reader[item.Name].ToString());
                                    break;

                                case "Int32":
                                    item.SetValue(obj, int.Parse(reader[item.Name].ToString()));
                                    break;

                                case "Decimal":
                                    item.SetValue(obj, decimal.Parse(reader[item.Name].ToString()));
                                    break;

                                case "DateTime":
                                    try
                                    {
                                        if (reader[item.Name] != null)
                                            item.SetValue(obj, Convert.ToDateTime(reader[item.Name].ToString()));
                                    }
                                    catch { }
                                    break;

                                default:
                                    break;
                            }
                        }
                        ListAgenda.Add(obj);
                    }
                }
                return ListAgenda;
            }
        }

        private string GetStringSQL(string paciente, string dtInicial, string dtFim, string horaInicial, string horaFinal,
            string servico, string situacao)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbAux = new StringBuilder();
            DateTime inicialDate, finalDate;
            sb.Append("select *from Agenda ");

            if (!string.IsNullOrWhiteSpace(paciente.Trim()))
                sbAux.Append($"where PacienteNome like '{paciente.Trim()}%'");

            if (!string.IsNullOrWhiteSpace(dtInicial) && string.IsNullOrWhiteSpace(dtInicial) && DateTime.TryParse(dtInicial, out inicialDate)
                && DateTime.TryParse(dtFim, out finalDate))
            {
                if (string.IsNullOrWhiteSpace(horaInicial.Trim()) && string.IsNullOrWhiteSpace(horaFinal.Trim()))
                {
                    if (string.IsNullOrWhiteSpace(sbAux.ToString()))
                        sbAux.Append($"where Data between '{inicialDate.ToString("yyyy-MM-dd")}' and '{ finalDate.ToString("yyyy-MM-dd")}' ");
                    else
                        sbAux.Append($"and  Data between '{inicialDate.ToString("yyyy-MM-dd")}' and '{finalDate.ToString("yyyy-MM-dd")}' ");
                }
                else if (!string.IsNullOrWhiteSpace(horaInicial) && !string.IsNullOrWhiteSpace(horaFinal))
                {
                    if (string.IsNullOrWhiteSpace(sbAux.ToString()))
                        sbAux.Append($"where Data between '{inicialDate.ToString("yyyy-MM-dd")}' and '{ finalDate.ToString("yyyy-MM-dd")}'" +
                            $"and Horas between '{horaInicial}' and '{horaFinal}'");
                    else
                        sbAux.Append($"and  Data between '{inicialDate.ToString("yyyy-MM-dd")}' and '{finalDate.ToString("yyyy-MM-dd")}' " +
                            $"and Horas between '{horaInicial}' and '{horaFinal}'");
                }
                else if (!string.IsNullOrWhiteSpace(horaInicial))
                {
                    if (string.IsNullOrWhiteSpace(sbAux.ToString()))
                        sbAux.Append($"where Data between '{inicialDate.ToString("yyyy-MM-dd")}' and '{ finalDate.ToString("yyyy-MM-dd")}'" +
                            $"and Horas between '{horaInicial}' and '{horaFinal}'");
                    else
                        sbAux.Append($"and  Data between '{inicialDate.ToString("yyyy-MM-dd")}' and '{ finalDate.ToString("yyyy-MM-dd")}' " +
                                $"and Horas = '{horaInicial}'");
                }
                else if (!string.IsNullOrWhiteSpace(horaFinal))
                {
                    if (string.IsNullOrWhiteSpace(sbAux.ToString()))
                        sbAux.Append($"where Data between '{inicialDate.ToString("yyyy-MM-dd")}' and '{ finalDate.ToString("yyyy-MM-dd")}'" +
                            $"and Horas between '{horaInicial}' and '{horaFinal}'");
                    else
                        sbAux.Append($"and  Data between '{inicialDate.ToString("yyyy-MM-dd")}' and '{ finalDate.ToString("yyyy-MM-dd")}' " +
                                $"and Horas = {horaFinal}'");
                }
            }
            else if (!string.IsNullOrWhiteSpace(dtInicial.Trim()) && DateTime.TryParse(dtInicial, out inicialDate))
            {
                if (string.IsNullOrWhiteSpace(horaInicial.Trim()) && string.IsNullOrWhiteSpace(horaFinal.Trim()))
                {
                    if (string.IsNullOrWhiteSpace(sbAux.ToString()))
                        sbAux.Append($"where Data = '{inicialDate.ToString("yyyy-MM-dd")}'");
                    else
                        sbAux.Append($"and  Data = '{inicialDate.ToString("yyyy-MM-dd")}' ");
                }
                else if (!string.IsNullOrWhiteSpace(horaInicial) && !string.IsNullOrWhiteSpace(horaFinal))
                {
                    if (string.IsNullOrWhiteSpace(sbAux.ToString()))
                        sbAux.Append($"where Data = '{inicialDate.ToString("yyyy-MM-dd")}' " +
                            $"and Horas between '{horaInicial}' and '{horaFinal}'");
                    else
                        sbAux.Append($"and  Data = '{inicialDate.ToString("yyyy-MM-dd")}'" +
                            $"and Horas between '{horaInicial}' and '{horaFinal}'");
                }
                else if (!string.IsNullOrWhiteSpace(horaInicial))
                {
                    if (string.IsNullOrWhiteSpace(sbAux.ToString()))
                        sbAux.Append($"where Data = '{inicialDate.ToString("yyyy-MM-dd")}'" +
                            $"and Horas = '{horaInicial}' ");
                    else
                        sbAux.Append($"and  Data = '{inicialDate.ToString("yyyy-MM-dd")}'" +
                                $"and Horas = '{horaInicial}'");
                }
                else if (!string.IsNullOrWhiteSpace(horaFinal))
                {
                    if (string.IsNullOrWhiteSpace(sbAux.ToString()))
                        sbAux.Append($"where Data = '{inicialDate.ToString("yyyy-MM-dd")}'" +
                            $"and Horas = {horaFinal}");
                    else
                        sbAux.Append($"and  Data = '{inicialDate.ToString("yyyy-MM-dd")}' " +
                                $"and Horas = {horaFinal}'");
                }
            }
            else if (!string.IsNullOrWhiteSpace(dtFim.Trim()) && DateTime.TryParse(dtFim, out finalDate))
            {
                if (string.IsNullOrWhiteSpace(horaInicial.Trim()) && string.IsNullOrWhiteSpace(horaFinal.Trim()))
                {
                    if (string.IsNullOrWhiteSpace(sbAux.ToString()))
                        sbAux.Append($"where Data = '{finalDate.ToString("yyyy-MM-dd")}' ");
                    else
                        sbAux.Append($"and  Data = '{finalDate.ToString("yyyy-MM-dd")}' ");
                }
                else if (!string.IsNullOrWhiteSpace(horaInicial) && !string.IsNullOrWhiteSpace(horaFinal))
                {
                    if (string.IsNullOrWhiteSpace(sbAux.ToString()))
                        sbAux.Append($"where Data = '{finalDate.ToString("yyyy-MM-dd")}' " +
                            $"and Horas between '{horaInicial}' and '{horaFinal}'");
                    else
                        sbAux.Append($"and  Data = '{finalDate.ToString("yyyy-MM-dd")}'" +
                            $"and Horas between '{horaInicial}' and '{horaFinal}'");
                }
                else if (!string.IsNullOrWhiteSpace(horaInicial))
                {
                    if (string.IsNullOrWhiteSpace(sbAux.ToString()))
                        sbAux.Append($"where Data = '{finalDate.ToString("yyyy-MM-dd")}'" +
                            $"and Horas = '{horaInicial}' ");
                    else
                        sbAux.Append($"and  Data = '{finalDate.ToString("yyyy-MM-dd")}'" +
                                $"and Horas = '{horaInicial}'");
                }
                else if (!string.IsNullOrWhiteSpace(horaFinal))
                {
                    if (string.IsNullOrWhiteSpace(sbAux.ToString()))
                        sbAux.Append($"where Data = '{finalDate.ToString("yyyy-MM-dd")}'" +
                            $"and Horas = '{horaFinal}'");
                    else
                        sbAux.Append($"and  Data = '{finalDate.ToString("yyyy-MM-dd")}' " +
                                $"and Horas = '{horaFinal}'");
                }
            }

            if (!string.IsNullOrWhiteSpace(servico.Trim()))
            {
                if (string.IsNullOrWhiteSpace(sbAux.ToString()))
                    sbAux.Append($"where Tipo = '{servico.Trim()}'");
                else
                    sbAux.Append($"and  Data = '{servico.Trim()}' ");
            }

            if (!string.IsNullOrWhiteSpace(situacao.Trim()))
            {
                if (string.IsNullOrWhiteSpace(sbAux.ToString()))
                    sbAux.Append($"where Situation = '{situacao.Trim()}'");
                else
                    sbAux.Append($"and  Situation = '{situacao.Trim()}' ");
            }

            sbAux.Append(" Order by PacienteNome, Data, Horas ");

            sb.Append(sbAux.ToString());

            return sb.ToString();
        }

        public static Agenda GetAgenda(DateTime dtInicial, string horaInicial, long id)
        {
            string data = dtInicial.ToString("yyyy-MM-dd");
            string hora = horaInicial;
            StringBuilder sb = new StringBuilder();
            Agenda obj = new Agenda();
            Banco _banco = new Banco();

            using (var cmd = _banco.DbConnection())
            {
                if (id > 0)
                    sb.Append($"select *from Agenda where Data = '{ data }' and Horas = '{hora}' and Id = {id} ");
                else
                    sb.Append($"select *from Agenda where Data = '{ data }' and Horas = '{hora}' LIMIT 1 ");

                SQLiteCommand comand = new SQLiteCommand(sb.ToString());
                comand.Connection = cmd;
                PropertyInfo[] properties = obj.GetType().GetProperties();
                using (var reader = comand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                    {
                        obj = Activator.CreateInstance<Agenda>();
                        foreach (PropertyInfo item in properties)
                        {
                            switch (item.PropertyType.Name)
                            {
                                case "String":
                                    item.SetValue(obj, reader[item.Name].ToString());
                                    break;
                                case "Int32":
                                    item.SetValue(obj, int.Parse(reader[item.Name].ToString()));
                                    break;
                                case "Decimal":
                                    item.SetValue(obj, decimal.Parse(reader[item.Name].ToString()));
                                    break;
                                case "DateTime":
                                    try
                                    {
                                        if (reader[item.Name] != null)
                                            item.SetValue(obj, Convert.ToDateTime(reader[item.Name].ToString()));
                                    }
                                    catch { }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    if (obj.Id > 0)
                        return obj;

                    return null;
                }
            }
        }
    }
}
