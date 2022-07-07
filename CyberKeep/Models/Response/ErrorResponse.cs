using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberKeep.Models.Response
{
    public class ErrorResponse : BaseResponse
    {
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
        public string Data { get; set; }
    }
}
