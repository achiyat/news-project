using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace News.Entities.source
{
    public class SourceManager : BaseEntity
    {
        Logger Log;
        public Walla MySourceWalla { get; set; }
        public Maariv MySourceMaariv { get; set; }
        public Ynet MySourceYnet { get; set; }

        public SourceManager(Logger log) : base(log)
        {
            Log = LogManager;
            Task.Run(getInfoFromSource);
        }

        public void getInfoFromSource()
        {
            while (true)
            {
                MySourceWalla = new Walla();
                MySourceMaariv = new Maariv();
                MySourceYnet = new Ynet();
                Thread.Sleep(1000*60*60);
            }
        }


    }

    public interface ISource
    {
        void CreatingArticle(Dictionary<string, string> listArticle);
        void ImportInfo(string NameCategory, string url, string source, int Count); // async ?
    }
}
