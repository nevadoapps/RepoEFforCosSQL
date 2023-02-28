using Newtonsoft.Json;

namespace RepoEFCosSQLWeb.Entities
{
    public class BaseEntity
    {
        [JsonProperty("id")]
        public string? Id { get; set; }
    }
}
