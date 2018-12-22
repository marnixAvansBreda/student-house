using Newtonsoft.Json;

namespace StudentHouse.Models
{
    public sealed class RouteLink : Link
    {
        [JsonIgnore]
        public string RouteName { get; set; }

        [JsonIgnore]
        public object RouteValues { get; set; }
    }
}
