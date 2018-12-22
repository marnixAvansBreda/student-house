namespace StudentHouse.Models
{
    public class RootResource : Resource
    {
        public Link Students { get; set; }

        public Link Meals { get; set; }
    }
}
