using News.Entities.source;
using News.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static News.Entities.Logger;

namespace News.Entities
{
    public class MainManager
    {
        // singelton
        private MainManager()
        {
            init();
        }

        private static readonly MainManager instance = new MainManager();
        public static MainManager Instance { get { return instance; } }


        public Logger logger;
        public Users users;
        public Articles articles;
        public SourceManager SourceManager;
        public Categories categories; 

        public void init()
        {
            logger = new Logger(providerType.logConsole);
            users = new Users(logger);
            SourceManager = new SourceManager(logger);
            articles = new Articles(logger);
            categories = new Categories(logger);
        }
    }
}
