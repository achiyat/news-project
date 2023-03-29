using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using News.Entities;
using News.Model;

namespace News.Controllers
{
    [ApiController]
    [Route("api/News/Article")]
    public class NewsArticleController : ControllerBase
    {
        Dictionary<string, Article> ListArticle = new Dictionary<string, Article>();
        Article article = new Article();
        string Query;

        [HttpGet("GetAllArticles")]
        public JsonResult GetAllArticles()
        {
            try
            {
                Query = "select * from Articles  ORDER BY ArticleDate DESC";
                ListArticle = (Dictionary<string, Article>)MainManager.Instance.articles.ImportData(Query);
                return new JsonResult(ListArticle);
            }
            catch (Exception ex)
            {
                MainManager.Instance.logger.Exception($"Article/Get All Articles : {ex.Message}", ex);
                return new JsonResult("not ok");
            }
        }

        [HttpGet("GetAllArticlesForHome")]
        public JsonResult GetAllArticlesForHome(string Category1, string Category2, string Category3)
        {
            // string Category1, string Category2, string Category3
            try
            {
                string queryWhere = "";

                if (Category1 == "null") { return new JsonResult("failed"); }
                else if(Category2 == "null") {queryWhere = $"WHERE NameCategory = '{Category1}'"; }
                else if (Category3 == "null") { queryWhere = $"WHERE NameCategory IN ('{Category1}', '{Category2}')"; }
                else if (Category3 != "null") { queryWhere = $"WHERE NameCategory IN ('{Category1}', '{Category2}', '{Category3}')"; }


                Query = $"SELECT * FROM (\r\nSELECT TOP 10 * FROM Articles {queryWhere} AND Namesource = 'וואלה' ORDER BY ArticleDate\r\nUNION ALL\r\nSELECT TOP 10 * FROM Articles {queryWhere} AND Namesource = 'מעריב' ORDER BY ArticleDate\r\nUNION ALL\r\nSELECT TOP 10 * FROM Articles {queryWhere} AND Namesource = 'ynet' ORDER BY ArticleDate\r\n) AS combined_table ORDER BY ArticleDate DESC";

                ListArticle = (Dictionary<string, Article>)MainManager.Instance.articles.ImportData(Query);
                return new JsonResult(ListArticle);
            }
            catch (Exception ex)
            {
                MainManager.Instance.logger.Exception($"Article/Get All Articles : {ex.Message}", ex);
                return new JsonResult("not ok");
            }
        }

        [HttpGet("GetArticleByIdCategory/{Category}")]
        public JsonResult GetArticleByIdCategory(string Category)
        {
            try
            {
                Query = $"select * from Articles where NameCategory = '{Category}' ORDER BY ArticleDate DESC";
                ListArticle = (Dictionary<string, Article>)MainManager.Instance.articles.ImportData(Query);
                return new JsonResult(ListArticle);
            }
            catch (Exception ex)
            {
                MainManager.Instance.logger.Exception($"Article/Get All Articles : {ex.Message}", ex);
                return new JsonResult("not ok");
            }
        }

        [HttpPut("UpdatePopularityArticle/{IdArticle}")]
        public JsonResult UpdatePopularityArticle(string IdArticle)
        {
            try
            {
                Query = $"select * from Articles where IdArticle = '{IdArticle}'";
                ListArticle = (Dictionary<string, Article>)MainManager.Instance.articles.ImportData(Query);
                ListArticle[IdArticle].popularity++;

                Query = $"update Articles set popularity = {ListArticle[IdArticle].popularity} where IdArticle = '{IdArticle}'";
                MainManager.Instance.articles.ExportFromDB(Query);
                return new JsonResult("ok");
            }
            catch (Exception ex)
            {
                MainManager.Instance.logger.Exception($"Article/Get All Articles : {ex.Message}", ex);
                return new JsonResult("not ok");
            }
        }
    }
}