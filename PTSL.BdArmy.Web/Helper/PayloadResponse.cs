using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTSL.BdArmy.Web.Helper
{
    public class PayloadResponse
    {
        public string RequestTime { get; set; }
        public string ResponseTime { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Payload { get; set; }
    }
}
