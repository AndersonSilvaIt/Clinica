using Data.Entidades;
using System;
using System.Data;
using System.Data.SQLite;
using System.Reflection;

namespace Data.SQLiteORM.Repository
{
    public class ClienteRepositorySQLite : BaseRepository<Cliente>
    {
        public Cliente LastId()
        {
            Cliente cliente = new Cliente();

            string sql = $"select *from cliente order by id desc limit 1";
            Banco _banco = new Banco();
            using (var cmd = _banco.DbConnection())
            {
                SQLiteCommand comand = new SQLiteCommand(sql);
                comand.Connection = cmd;
                PropertyInfo[] properties = cliente.GetType().GetProperties();

                using (var reader = comand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (reader.Read())
                    {
                        foreach (PropertyInfo item in properties)
                        {
                            switch (item.PropertyType.Name)
                            {
                                case "String":
                                    item.SetValue(cliente, reader[item.Name].ToString());
                                    break;

                                case "Int32":
                                    item.SetValue(cliente, int.Parse(reader[item.Name].ToString()));
                                    break;

                                case "Decimal":
                                    item.SetValue(cliente, decimal.Parse(reader[item.Name].ToString()));
                                    break;

                                case "DateTime":
                                    try
                                    {
                                        if (reader[item.Name] != null)
                                            item.SetValue(cliente, Convert.ToDateTime(reader[item.Name].ToString()));
                                    }
                                    catch { }
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                    return cliente;
                }
            }
        }
    }
}
