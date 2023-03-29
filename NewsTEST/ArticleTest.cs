using News.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsTEST
{
    [TestFixture]
    internal class ArticleTest
    {
        Dictionary<string, Article> ListArticle = new Dictionary<string, Article>();
        Article article = new Article();
        string Query;

        [Test, Order(1), Category("from class NewsArticleController")]
        public void GetAllArticles()
        {

        }

        //[Test, Order(2), Category("from class NewsArticleController")]
        //public void GetAllArticlesForHome()
        //{

        //}

        //[Test, Order(3), Category("from class NewsArticleController")]
        //public void GetArticleByIdCategory()
        //{

        //}

        //[Test, Order(4), Category("from class NewsArticleController")]
        //public void UpdatePopularityArticle()
        //{

        //}

        //[Test, Order(5), Category("from class NewsArticleController")]
        //public void DeleteArticle()
        //{

        //}
    }
}
