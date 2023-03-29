using Microsoft.AspNetCore.Mvc;
using News.Entities;
using News.Model;
using System.Security.Cryptography.Xml;

namespace News.Controllers
{
    [ApiController]
    [Route("api/News/Category")]
    public class NewsCategoryController : ControllerBase
    {
        Dictionary<int, Category> ListCategory;
        Dictionary<string, string> category = new Dictionary<string, string>();
        Category c = new Category();
        string Query;

        [HttpGet("GetCategory")]
        public JsonResult GetCategory()
        {
            try
            {
                Query = "select * from Categories";
                ListCategory = (Dictionary<int, Category>)MainManager.Instance.categories.ImportData(Query);

                foreach (KeyValuePair<int, Category> Category in ListCategory)
                {
                    if (!category.ContainsKey(Category.Value.NameCategory))
                    {
                        category.Add(Category.Value.NameCategory, Category.Value.NameCategory);
                    }
                }

                return new JsonResult(category);
            }
            catch (Exception ex)
            {
                MainManager.Instance.logger.Exception($"Activist/AddActivist : {ex.Message}", ex);
                return new JsonResult("not ok");
            }
        }
    }
}