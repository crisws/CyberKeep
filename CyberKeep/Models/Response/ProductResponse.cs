using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberKeep.Models.Response
{
    public class ProductResponse : BaseResponse
    {
        public DateTime InitialDate { get; set; }
        public string SKU { get; set; }
        public decimal ActualPrice { get; set; }
        public List<HistoriesResponse> Histories { get; set; }
    }
}
