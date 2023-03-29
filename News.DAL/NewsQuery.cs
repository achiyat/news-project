using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL
{
    public class NewsQuery
    {
        public delegate void delegateReader(SqlDataReader reader);
        public delegate void delegateCommand(SqlCommand command);

        public static void ImportDataFromDB(string SqlQuery, delegateReader Ptrfunc)
        {
            //string connectionString = ConfigurationManager.AppSettings["connectionString"];
            string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=News;Data Source=LAPTOP-V5QEKNGK\\SQLEXPRESS01";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = SqlQuery;
                connection.Open();

                // Adapter
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    //Reader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Ptrfunc(reader);
                    }
                }
            }
        }

        public static void InputToDB(string SqlQuery, delegateCommand Ptrfunc)
        {
            //string connectionString = ConfigurationManager.AppSettings["connectionString"];
            string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=News;Data Source=LAPTOP-V5QEKNGK\\SQLEXPRESS01";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string queryString = SqlQuery;
                connection.Open();

                // Adapter
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    Ptrfunc(command);
                }
            }
        }

    }
}
