using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Entities.source
{
    public abstract class BaseSource
    {
        public static string AllCommandInsert = "";
        public static int counter = 0;
        public virtual void InsertAllArticle(string CommandInsert)
        {
            MainManager.Instance.articles.ImportData(CommandInsert);
        }

        public void Done()
        {
            counter++;
            if(counter == 3)
            {
                InsertAllArticle(AllCommandInsert);
                //counter = 0;
            }

            if (counter > 3)
            {
                int a = 0;
            }

        }

    }
}
