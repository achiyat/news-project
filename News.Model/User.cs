using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Model
{
    public class User
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string PopularCategory { get; set; }
        public string Category1 { get; set; }
        public string Category2 { get; set; }
        public string Category3 { get; set; }
        public int HowPopularCategory1 { get; set; }
        public int HowPopularCategory2 { get; set; }
        public int HowPopularCategory3 { get; set; }
    }

}
