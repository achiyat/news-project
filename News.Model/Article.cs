using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Model
{
    public class Article
    {
        public string IdArticle { get; set; }
        public string NameCategory { get; set; }
        public string Namesource { get; set; }
        public string title { get; set; }
        public string secondaryTitle { get; set; }
        public DateTime ArticleDate { get; set; }
        public string Img { get; set; }
        public string Link { get; set; }
        public int popularity { get; set; }
    }

}
