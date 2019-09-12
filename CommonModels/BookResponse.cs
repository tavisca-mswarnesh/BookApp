using System;
using System.Collections.Generic;
using System.Text;

namespace CommonModels
{
    public class BookResponse
    {
        public bool Status { get; set; }
        public object Value { get; set; }
        public List<string> Message { get; set; }
        
    }
}
