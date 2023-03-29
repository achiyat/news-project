using News.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace News.Entities.source
{
    public class Maariv : BaseSource, ISource
    {
        // IdArticle,NameCategory,Namesource,title,secondaryTitle,Img,Link,popularity
        public int counterDone = 0;
        Dictionary<string, string> ListArticle = new Dictionary<string, string>();
        Dictionary<int, Category> ListCategory;

        public Maariv()
        {
            try
            {
                string Query = "select * from Categories where Source = 'מעריב'";
                ListCategory = (Dictionary<int, Category>)MainManager.Instance.categories.ImportData(Query);

                foreach (KeyValuePair<int, Category> Category in ListCategory)
                {
                    ListArticle.Add(Category.Value.NameCategory, Category.Value.URL);
                }

                CreatingArticle(ListArticle);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void CreatingArticle(Dictionary<string, string> listArticle)
        {
            try
            {
                foreach (KeyValuePair<string, string> article in listArticle)
                {
                    ImportInfo(article.Key, article.Value, "מעריב", listArticle.Count);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public async void ImportInfo(string NameCategory, string url, string source, int Count)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);

                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync();

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(content);

                    foreachs(doc, NameCategory, url, source, Count);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void foreachs(XmlDocument doc, string NameCategory, string url, string source, int Count)
        {
            foreach (XmlNode node in doc.SelectNodes("//item"))
            {
                string itemID = node["itemID"].InnerText;
                string title = node["title"].InnerText.Replace("'", "");
                string link = node["link"].InnerText;

                string Date = node["pubDate"].InnerText;
                DateTime ArticleDate = DateTime.ParseExact(Date, "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture);

                string[] outputStrings = node["description"].InnerText.Split(new string[] { "<br/>" }, StringSplitOptions.None);
                string img = outputStrings[0].Split('\'')[7].Trim();
                string description = outputStrings[1].Replace("'", "").Trim();


                string CommandInsert = $"insert into Articles values('{itemID}','{NameCategory}','{source}','{title}','{description}','{ArticleDate}','{img}','{link}',0)\r\n";
                AllCommandInsert = AllCommandInsert + CommandInsert;
            }

            counterDone++;
            if (counterDone == Count)
            {
                Done();
                //counterDone = 0;
                //int a = 0;
            }

            if (counterDone > Count)
            {
                counterDone = 0;
            }
        }
    }
}

//foreach (XmlNode node in doc.SelectNodes("//item"))
//{
//    string itemID = node["itemID"].InnerText;
//    string title = node["title"].InnerText.Replace("'", "");
//    string link = node["link"].InnerText;

//    string Date = node["pubDate"].InnerText;
//    DateTime ArticleDate = DateTime.ParseExact(Date, "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture);

//    string[] outputStrings = node["description"].InnerText.Split(new string[] { "<br/>" }, StringSplitOptions.None);
//    string img = outputStrings[0].Split('\'')[7].Trim();
//    string description = outputStrings[1].Replace("'", "").Trim();


//    string CommandInsert = $"insert into Articles values('{itemID}','{NameCategory}','{source}','{title}','{description}','{ArticleDate}','{img}','{link}',0)\r\n";
//    AllCommandInsert = AllCommandInsert + CommandInsert;
//}

//counterDone++;
//if (counterDone == Count)
//{
//    Done();
//    counterDone = 0;
//}