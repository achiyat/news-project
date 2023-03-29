using News.Entities;
using News.Model;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsTEST
{
    [TestFixture]
    internal class CategoryTest
    {
        Dictionary<int, Category> ListCategory;
        Dictionary<string, string> category = new Dictionary<string, string>();
        Category c = new Category();
        string Query;

        [Test, Order(1), Category("from class NewsCategoryController")]
        public void GetCategory()
        {
            string stringTEST = "{\r\n  \"בריאות\": \"בריאות\",\r\n  \"ספורט\": \"ספורט\",\r\n  \"תרבות\": \"תרבות\",\r\n  \"רכב\": \"רכב\",\r\n  \"תיירות\": \"תיירות\",\r\n  \"כלכלה\": \"כלכלה\",\r\n  \"אוכל\": \"אוכל\",\r\n  \"יהדות\": \"יהדות\",\r\n  \"הורות\": \"הורות\"\r\n}";

            Query = "select * from Categories";
            ListCategory = (Dictionary<int, Category>)MainManager.Instance.categories.ImportData(Query);

            foreach (KeyValuePair<int, Category> Category in ListCategory)
            {
                if (!category.ContainsKey(Category.Value.NameCategory))
                {
                    category.Add(Category.Value.NameCategory, Category.Value.NameCategory);
                }
            }

            string json = JsonConvert.SerializeObject(category, Formatting.Indented);

            Assert.AreEqual(json, stringTEST, "should be Equal");
        }
    }
}
