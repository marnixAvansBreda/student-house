using Newtonsoft.Json;

namespace StudentHouse.Models
{
    public abstract class Resource : Link
    {
        [JsonIgnore]
        public Link Self { get; set; }
    }
}
