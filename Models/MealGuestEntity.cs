using System;

namespace StudentHouse.Models
{
    public class MealGuestEntity
    {
        public Guid MealId { get; set; }

        public MealEntity Meal { get; set; }

        public Guid GuestId { get; set; }

        public StudentEntity Guest { get; set; }
    }
}
