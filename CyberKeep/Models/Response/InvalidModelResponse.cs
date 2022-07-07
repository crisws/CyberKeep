using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberKeep.Models.Response
{
    public class InvalidModelResponse : BaseResponse
    {
        public InvalidModelResponse(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary modelState)
        {
            this.Error = true;
            this.Message = "Modelo no valido";
            this.InvalidModels = new List<object>();
            foreach (var modelStateKey in modelState.Keys)
            {
                var value = modelState[modelStateKey];
                foreach (var error in value.Errors)
                {
                    InvalidModels.Add(new
                    {
                        Key = modelStateKey,
                        Error = error.ErrorMessage
                    });
                }
            }

        }

        public List<object> InvalidModels { get; set; }
    }
}
