using News.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace News.Entities
{
    public class Users : BaseEntity
    {
        Logger Log;
        public Users(Logger log) : base(log)
        {
            Log = LogManager;
        }

        public List<User> ListUser = new List<User>();

        // ייבוא נתונים - 1
        // Gives a command to DAL to create a connection with SQL for Import
        public object ImportData(string SqlQuery)
        {
            DAL.NewsQuery.ImportDataFromDB(SqlQuery, ReadFromDb);
            return ListUser;
        }

        // ייבוא נתונים - 2
        // Imports the data from the database into the server
        public void ReadFromDb(SqlDataReader reader)
        {
            //Clear Hashtable Before Inserting Information From Sql Server
            ListUser.Clear();
            while (reader.Read())
            {
                User GetUser = new User();
                GetUser.UserId = reader.GetString(reader.GetOrdinal("UserId"));
                GetUser.Email = reader.GetString(reader.GetOrdinal("Email"));
                GetUser.PopularCategory = reader.GetString(reader.GetOrdinal("PopularCategory"));
                GetUser.Category1 = reader.GetString(reader.GetOrdinal("Category1"));
                GetUser.Category2 = reader.GetString(reader.GetOrdinal("Category2"));
                GetUser.Category3 = reader.GetString(reader.GetOrdinal("Category3"));
                GetUser.HowPopularCategory1 = reader.GetInt32(reader.GetOrdinal("HowPopularCategory1"));
                GetUser.HowPopularCategory2 = reader.GetInt32(reader.GetOrdinal("HowPopularCategory2"));
                GetUser.HowPopularCategory3 = reader.GetInt32(reader.GetOrdinal("HowPopularCategory3"));

                //Cheking If Hashtable contains the key
                if (ListUser.Contains(GetUser))
                {
                    //key already exists
                }
                else
                {
                    //Filling a hashtable
                    ListUser.Add(GetUser);
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
