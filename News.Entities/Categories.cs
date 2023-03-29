using News.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Entities
{
    public class Categories : BaseEntity
    {
        Logger Log;
        public Categories(Logger log) : base(log)
        {
            Log = LogManager;
        }

        public Dictionary<int, Category> ListCategory = new Dictionary<int, Category>();

        // ייבוא נתונים - 1
        // Gives a command to DAL to create a connection with SQL for Import
        public object ImportData(string SqlQuery)
        {
            DAL.NewsQuery.ImportDataFromDB(SqlQuery, ReadFromDb);
            return ListCategory;
        }

        // ייבוא נתונים - 2
        // Imports the data from the database into the server
        public void ReadFromDb(SqlDataReader reader)
        {
            //Clear Hashtable Before Inserting Information From Sql Server
            ListCategory.Clear();
            while (reader.Read())
            {
                Category GetCategory = new Category();
                GetCategory.IdCategory = reader.GetInt32(reader.GetOrdinal("IdCategory"));
                GetCategory.NameCategory = reader.GetString(reader.GetOrdinal("NameCategory"));
                GetCategory.Source = reader.GetString(reader.GetOrdinal("source"));
                GetCategory.URL = reader.GetString(reader.GetOrdinal("URL"));

                //Cheking If Dictionary contains the key
                if (ListCategory.ContainsKey(GetCategory.IdCategory))
                {
                    //key already exists
                }
                else
                {
                    //Filling a Dictionary
                    ListCategory.Add(GetCategory.IdCategory, GetCategory);
                }
            }
        }

        // ייצוא נתונים - 1
        // Gives a command to DAL to create a connection with SQL for Export
        public void ExportFromDB(string SqlQuery)
        {
            DAL.NewsQuery.InputToDB(SqlQuery, changeTheDB);
        }

        // ייצוא נתונים - 2
        // Exports the data from the server into the database
        public void changeTheDB(SqlCommand command)
        {
            command.ExecuteNonQuery();
        }
    }
}
