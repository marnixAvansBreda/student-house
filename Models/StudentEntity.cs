using System;
using System.Collections.Generic;

namespace StudentHouse.Models
{
    public class StudentEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string EMail { get; set; }

        public string PhoneNumber { get; set; }

        public List<MealGuestEntity> MealsAsGuest { get; set; }

        public List<MealEntity> MealsAsChef { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
