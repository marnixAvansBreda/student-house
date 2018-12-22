using System;
using System.Collections.Generic;

namespace StudentHouse.Models
{
    public class MealEntity
    {
        public Guid Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid ChefId { get; set; }

        public StudentEntity Chef { get; set; }

        public double Price { get; set; }

        public int MaxAmountOfGuests { get; set; }

        public List<MealGuestEntity> Guests { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
