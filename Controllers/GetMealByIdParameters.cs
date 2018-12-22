using System;
using Microsoft.AspNetCore.Mvc;

namespace StudentHouse.Controllers
{
    public class GetMealByIdParameters
    {
        [FromRoute]
        public Guid MealId { get; set; }
    }
}
