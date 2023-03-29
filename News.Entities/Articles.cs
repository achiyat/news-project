using News.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace News.Entities
{
    public class Articles : BaseEntity
    {
        Logger Log;
        public Articles(Logger log) : base(log)
        {
            Log = LogManager;
        }

        public Dictionary<string, Article> ListArticle = new Dictionary<string, Article>();

        // ייבוא נתונים - 1
        // Gives a command to DAL to create a connection with SQL for Import
        public object ImportData(string SqlQuery)
        {
            DAL.NewsQuery.ImportDataFromDB(SqlQuery, ReadFromDb);
            return ListArticle;
        }

        // ייבוא נתונים - 2
        // Imports the data from the database into the server
        public void ReadFromDb(SqlDataReader reader)
        {
            //Clear Hashtable Before Inserting Information From Sql Server
            ListArticle.Clear();
            while (reader.Read())
            {
                Article GetArticle = new Article();
                GetArticle.IdArticle = reader.GetString(reader.GetOrdinal("IdArticle"));
                GetArticle.NameCategory = reader.GetString(reader.GetOrdinal("NameCategory"));
                GetArticle.Namesource = reader.GetString(reader.GetOrdinal("Namesource"));
                GetArticle.title = reader.GetString(reader.GetOrdinal("title"));
                GetArticle.secondaryTitle = reader.GetString(reader.GetOrdinal("secondaryTitle"));
                GetArticle.ArticleDate = reader.GetDateTime(reader.GetOrdinal("ArticleDate"));
                GetArticle.Img = reader.GetString(reader.GetOrdinal("Img"));
                GetArticle.Link = reader.GetString(reader.GetOrdinal("Link"));
                GetArticle.popularity = reader.GetInt32(reader.GetOrdinal("popularity"));


                //Cheking If Dictionary contains the key
                if (ListArticle.ContainsKey(GetArticle.IdArticle))
                {
                    //key already exists
                }
                else
                {
                    //Filling a Dictionary
                    ListArticle.Add(GetArticle.IdArticle, GetArticle);
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
