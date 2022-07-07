using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CyberKeep.Data.Entity
{
    public class Products
    {
        [Key]
        public long Id { get; set; }
        public DateTime AddedDate { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        [JsonIgnore]
        public List<Histories> Histories { get; set; }

    }
}
