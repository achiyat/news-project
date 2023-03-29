using Microsoft.AspNetCore.Mvc;
using News.Entities;
using News.Model;
using System;
using System.Diagnostics;
using System.Security.Cryptography.Xml;

namespace News.Controllers
{
    [ApiController]
    [Route("api/News/User")]
    public class NewsUserController : ControllerBase
    {
        List<User> listUsers = new List<User>();
        User u = new User();
        User user = new User();
        UserCategory UC = new UserCategory();
        string Query;
        
        [HttpPost("saveUser")]
        public JsonResult SaveUserData(string UserId, string Email)
        {
            try
            {
                Query = $"insert into Users values ('{UserId}','{Email}','null','null','null','null',0,0,0)";
                MainManager.Instance.users.ExportFromDB(Query);
                return new JsonResult("ok");
            }
            catch (Exception ex)
            {
                MainManager.Instance.logger.Exception($"Activist/AddActivist : {ex.Message}", ex);
                return new JsonResult("not ok");
            }
        }

        [HttpPut("SaveCategory/{UserId}")]
        public JsonResult SaveCategory(string UserId, UserCategory ClassCategory)
        {
            //, string CTGY1, string CTGY2, string CTGY3
            try
            {
                UC = ClassCategory;
                if (UC.Category1 == "") { UC.Category1 = "null"; }
                if (UC.Category2 == "") { UC.Category2 = "null"; }
                if (UC.Category3 == "") { UC.Category3 = "null"; }
                Query = $"update Users set Category1 = '{UC.Category1}',Category2 = '{UC.Category2}',Category3 = '{UC.Category3}' where UserId = '{UserId}'";
                MainManager.Instance.users.ExportFromDB(Query);
                return new JsonResult("ok");
            }
            catch (Exception ex)
            {
                MainManager.Instance.logger.Exception($"Activist/AddActivist : {ex.Message}", ex);
                return new JsonResult("not ok");
            }
        }

        [HttpPost("GetCategoryOfUser/{UserId}")] // Get
        public JsonResult GetCategoryOfUser(string UserId)
        {
            //, string CTGY1, string CTGY2, string CTGY3
            try
            {
                Query = $"select * from Users where UserId='{UserId}'";
                listUsers = (List<User>)MainManager.Instance.users.ImportData(Query);
                UC.Category1 = listUsers[0].Category1;
                UC.Category2 = listUsers[0].Category2;
                UC.Category3 = listUsers[0].Category3;
                if (UC.Category1 == "null") { UC.Category1 = ""; }
                if (UC.Category2 == "null") { UC.Category2 = ""; }
                if (UC.Category3 == "null") { UC.Category3 = ""; }
                return new JsonResult(UC);
            }
            catch (Exception ex)
            {
                MainManager.Instance.logger.Exception($"Activist/AddActivist : {ex.Message}", ex);
                return new JsonResult("not ok");
            }
        }

        [HttpPut("UpdatePopularity")]
        public JsonResult UpdatePopularity(string UserId, string Category)
        {
            try
            {
                Query = $"select * from Users where UserId = '{UserId}'";
                listUsers = (List<User>)MainManager.Instance.users.ImportData(Query);
                u = listUsers.Find(x => x.UserId == UserId);

                if (Category == u.Category1) { u.HowPopularCategory1++; }
                else if (Category == u.Category2) { u.HowPopularCategory2++; }
                else if (Category == u.Category3) { u.HowPopularCategory3++; }

                if (u.HowPopularCategory1 > u.HowPopularCategory2 && u.HowPopularCategory1 > u.HowPopularCategory3) { u.PopularCategory = u.Category1; }
                else if (u.HowPopularCategory2 > u.HowPopularCategory1 && u.HowPopularCategory2 > u.HowPopularCategory3) { u.PopularCategory = u.Category2; }
                else if (u.HowPopularCategory3 > u.HowPopularCategory1 && u.HowPopularCategory3 > u.HowPopularCategory2) { u.PopularCategory = u.Category3; }
                Query = $"update Users set PopularCategory = '{u.PopularCategory}',HowPopularCategory1 = '{u.HowPopularCategory1}', HowPopularCategory2 = '{u.HowPopularCategory2}', HowPopularCategory3 = '{u.HowPopularCategory3}' where UserId = '{UserId}'";

                MainManager.Instance.users.ExportFromDB(Query);
                return new JsonResult("ok");
            }
            catch (Exception ex)
            {
                MainManager.Instance.logger.Exception($"Activist/AddActivist : {ex.Message}", ex);
                return new JsonResult("not ok");
            }
        }

    }
}