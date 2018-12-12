using Data.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Reflection;
using System.Text;

namespace Data.SQLiteORM.Repository
{
    public class BaseRepository<T> where T : EntidadeBase
    {
        private static Banco _banco = new Banco();

        public static void Save(T Entity)
        {
            using (var cmd = _banco.DbConnection().CreateCommand())
            {
                StringBuilder stringBuilder;
                PropertyInfo[] propertyInfos;
                propertyInfos = Entity.GetType().GetProperties();
                stringBuilder = new StringBuilder();

                stringBuilder.Append($"INSERT INTO {Entity.GetType().Name} ( ");
                foreach (var item in propertyInfos)
                {
                    if (item.Name.ToUpper() != "ID")
                        stringBuilder.Append($"{item.Name} ,");
                }

                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                stringBuilder.Append(") Values (");

                foreach (var item in propertyInfos)
                {
                    if (item.Name.ToUpper() != "ID")
                    {
                        var valor = item.GetValue(((object)Entity), null);
                        var tipo = item.PropertyType.Name;

                        switch (tipo)
                        {
                            case "String":
                                stringBuilder.Append($"'{valor}' ,");
                                break;

                            case "Int32":
                                stringBuilder.Append($"{valor} ,");
                                break;

                            case "Decimal":
                                if (valor.ToString().Contains(","))
                                {
                                    var value = valor.ToString().Replace(",", ".");
                                    stringBuilder.Append($"{value} ,");
                                }else
                                    stringBuilder.Append($"{valor} ,");
                                break;

                            case "DateTime":
                                stringBuilder.Append($"'{((DateTime)valor).ToString("yyyy-MM-dd")}' ,");
                                break;
                        }
                    }
                }
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                stringBuilder.Append(")");

                cmd.CommandText = stringBuilder.ToString();
                cmd.ExecuteNonQuery();
            }
        }

        public static IList<T> GetAll()
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            IList<T> listObject = new List<T>();
            //SQLiteDataReader da = null;
            DataTable dt = new DataTable();

            string sql = $"select *from {obj.GetType().Name} ";

            using (var cmd = _banco.DbConnection())
            {
                SQLiteCommand comand = new SQLiteCommand(sql);
                comand.Connection = cmd;
                PropertyInfo[] properties = obj.GetType().GetProperties();

                using (var reader = comand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (reader.Read())
                    {
                        obj = Activator.CreateInstance<T>();
                        foreach (PropertyInfo item in properties)
                        {
                            if (!string.IsNullOrWhiteSpace(reader[item.Name].ToString()))
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
                        listObject.Add(obj);
                    }

                    return listObject;
                }
            }
        }

        public static void Delete(T Entity)
        {
            try
            {
                using (var cmd = _banco.DbConnection().CreateCommand())
                {
                    var valor = Entity.GetType().GetProperty("Id").GetValue(((object)Entity), null);

                    string sqlCommand = $"DELETE FROM {Entity.GetType().Name} where Id = {valor} ";

                    cmd.CommandText = sqlCommand;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { }
        }


        public static void Update(T Entity)
        {
            string id = "";
            using (var cmd = _banco.DbConnection().CreateCommand())
            {
                StringBuilder stringBuilder;
                PropertyInfo[] propertyInfos;
                propertyInfos = Entity.GetType().GetProperties();
                stringBuilder = new StringBuilder();

                stringBuilder.Append($"UPDATE {Entity.GetType().Name} set ");

                foreach (var item in propertyInfos)
                {
                    if (item.Name.ToUpper() == "ID")
                    {
                        var valor = item.GetValue(((object)Entity), null);
                        //var tipo = item.PropertyType.Name;

                        id = valor.ToString();
                    }
                    else
                    {
                        var valor = item.GetValue(((object)Entity), null);
                        var tipo = item.PropertyType.Name;

                        switch (tipo)
                        {
                            case "String":
                                stringBuilder.Append($"{item.Name} = '{valor}' ,");
                                break;

                            case "Int32":
                                stringBuilder.Append($" {item.Name} = {valor} ,");
                                break;

                            case "Decimal":
                                stringBuilder.Append($" {item.Name} = {valor} ,");
                                break;

                            case "DateTime":
                                try
                                {
                                    stringBuilder.Append($" {item.Name} = '{((DateTime)valor).ToString("yyyy-MM-dd")}' ,");
                                }
                                catch { }
                                break;
                        }
                    }
                }

                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                stringBuilder.Append($" where id = { id} ");

                cmd.CommandText = stringBuilder.ToString();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
