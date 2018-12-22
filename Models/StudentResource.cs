using System;

namespace StudentHouse.Models
{
    public class StudentResource : Resource
    {
        public string Name { get; set; }

        public string EMail { get; set; }

        public string PhoneNumber { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public Link MealsAsGuest { get; set; }

        public Link MealsAsChef { get; set; }
    }
}
