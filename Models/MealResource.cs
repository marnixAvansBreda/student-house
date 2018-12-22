using System;

namespace StudentHouse.Models
{
    public class MealResource : Resource
    {
        public DateTime DateTime { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Link Chef { get; set; }

        public double Price { get; set; }

        public int MaxAmountOfGuests { get; set; }
        
        public DateTimeOffset CreatedAt { get; set; }

        public Link Guests { get; set; }
    }
}
