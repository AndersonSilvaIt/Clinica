using Data.Entidades;
using System;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using System.Text;

namespace Data.SQLiteORM
{
    public class Banco : IDisposable
    {
        private readonly string strPath = @"C:\DB\DBClinica.sqlite";
		private readonly string basePath = @"C:\DB";

		private static SQLiteConnection sqliteConnection;
        public Banco() 
        {
            try
            {
				if (!Directory.Exists(basePath))
					Directory.CreateDirectory(basePath);

                if (!File.Exists(strPath))
                    SQLiteConnection.CreateFile(strPath);

                CriarTabelas(typeof(Agenda));
                CriarTabelas(typeof(Cliente));
                CriarTabelas(typeof(Empresa));
                CriarTabelas(typeof(Tipo));
            }
            catch (Exception ex)
            {
            }
        }

        private void CriarTabelas(Type ClassType)
        {
            using (var cmd = DbConnection().CreateCommand())
            {
                StringBuilder stringBuilder;
                PropertyInfo[] propertyInfos;
                propertyInfos = ClassType.GetProperties();
                stringBuilder = new StringBuilder();
                stringBuilder.Append(string.Format( "CREATE TABLE IF NOT EXISTS {0} (", ClassType.Name));
                foreach (var item in propertyInfos)
                {
                    if (item.PropertyType.Name == "String")
                        stringBuilder.Append(string.Format("{0} varchar(50), ", item.Name));

                    if (item.PropertyType.Name == "Int32")
                    {
                        if(item.Name.ToUpper() == "ID")
                            stringBuilder.Append(string.Format("{0} INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT ,", item.Name));
                        else
                            stringBuilder.Append(string.Format("{0} INTEGER,", item.Name));
                    }
                    if (item.PropertyType.Name == "Decimal")
                        stringBuilder.Append(string.Format("{0} REAL, ", item.Name));

                    if (item.PropertyType.Name == "DateTime")
                        stringBuilder.Append(string.Format("{0} DATE, ", item.Name));
                }
                
                var valor = stringBuilder.ToString();
                var teste = valor.Remove(valor.LastIndexOf(',')) + ")";
                cmd.CommandText = teste;
                cmd.ExecuteNonQuery();
            }
        }


        public SQLiteConnection DbConnection()
        {
            sqliteConnection = new SQLiteConnection(@"Data Source=C:\DB\DBClinica.sqlite; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }

        public void Dispose()
        {
            try
            {
                sqliteConnection.Close();
            }catch(Exception ex) { }
        }
    }
}
