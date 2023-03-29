using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Entities
{
    public class BaseNews
    {
        public BaseNews(Logger Log)
        {
            LogManager = Log;
        }

        public Logger LogManager { get; set; }
    }
}
