using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;

namespace WebApi3.Models{
    public class ResponseClass{
        public string Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}