using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF
{
    public class ConeccaoSQLIte
    {

        private SQLiteConnection sqlite;

        public ConeccaoSQLIte()
        {
            //This part killed me in the beginning.  I was specifying "DataSource"
            //instead of "Data Source"
            //            sqlite = new SQLiteConnection(@"Data Source=C:\Users\Anderson\Desktop\dbclinica.db");

            sqlite = new SQLiteConnection(@"Data Source=C:\Users\Anderson\Desktop\dbclinica.db;Version=3;New=False;Compress=True;FailIfMissing=False;", true);

            //string.Format(@"Data Source={0};Version=3;New=False;Compress=True;", "~/lodeDb.db");
        }

        public DataTable List()
        {
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();

            SQLiteCommand cmd;
            sqlite.Open();
            cmd = sqlite.CreateCommand();
            cmd.CommandText = "select * from cliente ";
            ad = new SQLiteDataAdapter(cmd);
            ad.Fill(dt); //fill the datasource
                         //Add your exception code here.
            sqlite.Close();
            return dt;
        }


        public void Inserir(string sql)
        {
            SQLiteCommand cmd;

            sqlite.Open();
            cmd = sqlite.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            sqlite.Close();
        }
    }


}