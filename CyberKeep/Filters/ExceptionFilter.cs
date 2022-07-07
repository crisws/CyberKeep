using CyberKeep.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberKeep.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(new ErrorResponse
            {
                Error = true,
                Code = 500,
                Message = "Ocurrio un error no controlado",
                ErrorMessage = context.Exception.Message,
                StackTrace = context.Exception.ToString(),
                Data = context.Exception.Data.ToString(),
            });
        }
    }
}
