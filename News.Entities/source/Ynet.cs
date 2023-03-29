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
    public class Ynet : BaseSource, ISource
    {
        // IdArticle,NameCategory,Namesource,title,secondaryTitle,Img,Link,popularity
        public int counterDone = 0;
        Dictionary<string, string> ListArticle = new Dictionary<string, string>();
        Dictionary<int, Category> ListCategory;

        public Ynet()
        {
            try
            {
                string Query = "select * from Categories where Source = 'ynet'";
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
                    ImportInfo(article.Key, article.Value, "ynet", listArticle.Count);
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
                string title = node["title"].InnerText.Replace("'", "");
                string Date = node["pubDate"].InnerText;
                string link = node["link"].InnerText;

                DateTime ArticleDate = DateTime.ParseExact(Date, "ddd, dd MMM yyyy HH:mm:ss zzz", CultureInfo.InvariantCulture);

                string[] split = (Date + link).Split(new char[] { ' ', ',', '/' }, StringSplitOptions.None);
                string itemID = split[2] + split[3] + split[4] + split[5] + split[split.Length - 1];

                string inputString = node["description"].InnerText;
                string[] outputStrings = inputString.Split(new string[] { "src=", "alt=", "</div>" }, StringSplitOptions.None);
                string img = outputStrings[1].Replace("'", "");
                string description = outputStrings[3].Replace("'", "");


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
//    string title = node["title"].InnerText.Replace("'", "");
//    string Date = node["pubDate"].InnerText;
//    string link = node["link"].InnerText;

//    DateTime ArticleDate = DateTime.ParseExact(Date, "ddd, dd MMM yyyy HH:mm:ss zzz", CultureInfo.InvariantCulture);

//    string[] split = (Date + link).Split(new char[] { ' ', ',', '/' }, StringSplitOptions.None);
//    string itemID = split[2] + split[3] + split[4] + split[5] + split[split.Length - 1];

//    string inputString = node["description"].InnerText;
//    string[] outputStrings = inputString.Split(new string[] { "src=", "alt=", "</div>" }, StringSplitOptions.None);
//    string img = outputStrings[1].Replace("'", "");
//    string description = outputStrings[3].Replace("'", "");


//    string CommandInsert = $"insert into Articles values('{itemID}','{NameCategory}','{source}','{title}','{description}','{ArticleDate}','{img}','{link}',0)\r\n";
//    AllCommandInsert = AllCommandInsert + CommandInsert;
//}

//counterDone++;
//if (counterDone == Count)
//{
//    Done();
//    counterDone = 0;
//}