using News.Entities;
using News.Model;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace NewsTEST
{
    [TestFixture]
    internal class UserTest
    {
        List<User> listUsers = new List<User>();
        User u = new User();
        User user = new User();
        UserCategory UC = new UserCategory();
        string Query;

        [Test, Order(1), Category("from class NewsUserController")]
        public void SaveUser()
        {
            string stringTEST = "[\r\n  {\r\n    \"UserId\": \"1\",\r\n    \"Email\": \"2\",\r\n    \"PopularCategory\": \"null\",\r\n    \"Category1\": \"null\",\r\n    \"Category2\": \"null\",\r\n    \"Category3\": \"null\",\r\n    \"HowPopularCategory1\": 0,\r\n    \"HowPopularCategory2\": 0,\r\n    \"HowPopularCategory3\": 0\r\n  }\r\n]";
            Query = "insert into UsersTEST values ('1','2','null','null','null','null',0,0,0)";
            MainManager.Instance.users.ExportFromDB(Query);

            Query = "select * from UsersTEST where UserId = '1'";
            listUsers = (List<User>)MainManager.Instance.users.ImportData(Query);

            string json = JsonConvert.SerializeObject(listUsers, Formatting.Indented);

            Assert.AreEqual(json, stringTEST, "should be Equal");
        }

        [Test, Order(2), Category("from class NewsUserController")]
        public void SaveCategory()
        {
            string stringTEST = "[\r\n  {\r\n    \"UserId\": \"1\",\r\n    \"Email\": \"2\",\r\n    \"PopularCategory\": \"null\",\r\n    \"Category1\": \"aaa\",\r\n    \"Category2\": \"bbb\",\r\n    \"Category3\": \"null\",\r\n    \"HowPopularCategory1\": 0,\r\n    \"HowPopularCategory2\": 0,\r\n    \"HowPopularCategory3\": 0\r\n  }\r\n]";

            UC.Category1 = "aaa";
            UC.Category2 = "bbb";
            UC.Category3 = "";

            if (UC.Category1 == "") { UC.Category1 = "null"; }
            if (UC.Category2 == "") { UC.Category2 = "null"; }
            if (UC.Category3 == "") { UC.Category3 = "null"; }
            Query = $"update UsersTEST set Category1 = '{UC.Category1}',Category2 = '{UC.Category2}',Category3 = '{UC.Category3}' where UserId = '1'";
            MainManager.Instance.users.ExportFromDB(Query);

            Query = "select * from UsersTEST where UserId = '1'";
            listUsers = (List<User>)MainManager.Instance.users.ImportData(Query);
            string json = JsonConvert.SerializeObject(listUsers, Formatting.Indented);
            Assert.AreEqual(json, stringTEST, "should be Equal");
        }

        [Test, Order(3), Category("from class NewsUserController")]
        public void GetCategoryOfUser()
        {
            string stringTEST = "{\r\n  \"Category1\": \"aaa\",\r\n  \"Category2\": \"bbb\",\r\n  \"Category3\": \"\"\r\n}";
            UserCategory UC1 = new UserCategory();
            UC1.Category1 = "aaa";
            UC1.Category2 = "bbb";
            UC1.Category3 = "";

            Query = $"select * from UsersTEST where UserId='1'";
            listUsers = (List<User>)MainManager.Instance.users.ImportData(Query);
            UC.Category1 = listUsers[0].Category1;
            UC.Category2 = listUsers[0].Category2;
            UC.Category3 = listUsers[0].Category3;
            if (UC.Category1 == "null") { UC.Category1 = ""; }
            if (UC.Category2 == "null") { UC.Category2 = ""; }
            if (UC.Category3 == "null") { UC.Category3 = ""; }
            string json = JsonConvert.SerializeObject(UC, Formatting.Indented);
            Assert.AreEqual(json, stringTEST, "should be Equal");
        }

        [Test, Order(4), Category("from class NewsUserController")]
        public void UpdatePopularity()
        {
            string stringTEST = "[\r\n  {\r\n    \"UserId\": \"1\",\r\n    \"Email\": \"2\",\r\n    \"PopularCategory\": \"aaa\",\r\n    \"Category1\": \"aaa\",\r\n    \"Category2\": \"bbb\",\r\n    \"Category3\": \"null\",\r\n    \"HowPopularCategory1\": 1,\r\n    \"HowPopularCategory2\": 0,\r\n    \"HowPopularCategory3\": 0\r\n  }\r\n]";
            string Category = "aaa";

            Query = $"select * from UsersTEST where UserId = '1'";
            listUsers = (List<User>)MainManager.Instance.users.ImportData(Query);
            u = listUsers.Find(x => x.UserId == "1");

            if (Category == u.Category1) { u.HowPopularCategory1++; }
            else if (Category == u.Category2) { u.HowPopularCategory2++; }
            else if (Category == u.Category3) { u.HowPopularCategory3++; }

            if (u.HowPopularCategory1 > u.HowPopularCategory2 && u.HowPopularCategory1 > u.HowPopularCategory3) { u.PopularCategory = u.Category1; }
            else if (u.HowPopularCategory2 > u.HowPopularCategory1 && u.HowPopularCategory2 > u.HowPopularCategory3) { u.PopularCategory = u.Category2; }
            else if (u.HowPopularCategory3 > u.HowPopularCategory1 && u.HowPopularCategory3 > u.HowPopularCategory2) { u.PopularCategory = u.Category3; }

            Query = $"update UsersTEST set PopularCategory = '{u.PopularCategory}',HowPopularCategory1 = '{u.HowPopularCategory1}', HowPopularCategory2 = '{u.HowPopularCategory2}', HowPopularCategory3 = '{u.HowPopularCategory3}' where UserId = '1'";
            MainManager.Instance.users.ExportFromDB(Query);

            Query = "select * from UsersTEST where UserId = '1'";
            listUsers = (List<User>)MainManager.Instance.users.ImportData(Query);
            string json = JsonConvert.SerializeObject(listUsers, Formatting.Indented);
            Assert.AreEqual(json, stringTEST, "should be Equal");
        }

       [Test, Order(5),Category("from class NewsUserController")]
        public void DeleteUser()
        {
            string stringTEST = "";
            //Query = "insert into UsersTEST values ('1','2','null','null','null','null',0,0,0)";
            Query = "delete from UsersTEST where UserId = '1'";
            MainManager.Instance.users.ExportFromDB(Query);

            Query = "select * from UsersTEST where UserId = '1'";
            listUsers = (List<User>)MainManager.Instance.users.ImportData(Query);

            Assert.AreEqual(listUsers.Count, 0, "should be Equal");
        }
    }
}
