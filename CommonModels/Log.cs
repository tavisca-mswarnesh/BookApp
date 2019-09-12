using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModels
{
    public class Log
    {
        public DateTime Time { get; set; }
        public string MethodCalled { get; set; }
        public bool Status { get; set; }
        public List<string> Error { get; set; }
    }
}
