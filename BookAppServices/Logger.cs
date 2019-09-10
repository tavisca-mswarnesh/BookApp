using System;
using System.Diagnostics;
using System.IO;
using CommonModels;
namespace BookAppServices.Controllers
{
    public class Logger
    {
        public void write(Log log)
        {
            string path = "LoggerFile.txt";
            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            
            sw.Write($"{log.Time}\t{log.MethodCalled}\t{log.Status}\t");
            foreach (var error in log.Error)
            {
                sw.Write($"{error},");
            }
            sw.WriteLine("");
            sw.Flush();
            sw.Close();
            fs.Close();
            
            
        }
    }
}
