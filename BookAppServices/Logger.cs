using System;
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
            if (File.Exists(path))
            {
                
                sw.WriteLine($"{log.Time}\t{log.MethodCalled}\t{log.Status}\t{log.Error}");
                    
                
                    
                Console.WriteLine("File Found") ;
            }
        }
    }
}
