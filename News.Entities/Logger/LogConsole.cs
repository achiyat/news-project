using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Entities
{
    public class LogConsole : ILog
    {
        public void Init()
        {

        }

        public void LogEvent(string Message)
        {
            Console.WriteLine(Message);
        }

        public void LogError(string Message)
        {
            Console.WriteLine(Message);
        }
        public void LogException(string Message, Exception exce)
        {
            Console.WriteLine($"Error: {Message} Exception: {exce.Source}");
        }
        public void LogCheckHoseKeeping()
        {

        }
    }
}
