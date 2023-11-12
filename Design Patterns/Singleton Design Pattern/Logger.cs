using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Design_Pattern
{
    public class Logger
    {
        private static Logger _logger;

        private Logger() { }
        
        private static List<string> logs = new List<string>();

        public static Logger CreateLogger()
        {
            if (_logger == null)
            {
                _logger = new Logger();
            }
            return _logger;
        }

        public void Information(string message)
        {
            logs.Add(message);
        }
        
        public void GetLogs()
        {
            foreach(var log in logs)
            {
                Console.WriteLine(log);
            }
        }
    }
}
