using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoEFCosSQL.Entities
{
    public class BaseEntity
    {
        [JsonProperty("id")]
        public string? Id { get; set; }
    }
}
