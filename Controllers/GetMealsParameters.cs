using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StudentHouse.Controllers
{
    public class GetMealsParameters
    {
        [FromQuery]
        public DateTime DateTime { get; set; }

        [FromQuery]
        public string Name { get; set; }

        [FromQuery]
        public string Description { get; set; }

        [FromQuery]
        public Guid ChefId { get; set; }

        [FromQuery]
        public double Price { get; set; }

        [FromQuery]
        public int MaxAmountOfGuests { get; set; }

        public GetMealsParameters()
        {
            Price = -1;
            MaxAmountOfGuests = -1;
        }
    }
}
