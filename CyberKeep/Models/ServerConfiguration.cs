using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberKeep.Models
{
    public class ServerConfiguration
    {
        public string ContainerName { get; set; }
        public string BlobConnectionString { get; set; }
        public int TokenMinutes { get; set; }
        public int RefreshTokenHour { get; set; }
        public string Secret { get; set; }
        public int WorkFactor { get; set; }
        public decimal Version { get; set; }
        public string Enviroment { get; set; }
    }
}
