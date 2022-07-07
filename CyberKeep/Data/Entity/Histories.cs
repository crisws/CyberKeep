using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CyberKeep.Data.Entity
{
    public class Histories
    {
        [Key]
        public long Id { get; set; }

        [JsonIgnore]
        public Products Product { get; set; }

        public DateTime AddedDate { get; set; }
        public decimal Price { get; set; }

    }
}
