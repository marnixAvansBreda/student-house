using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StudentHouse.Infrastructure;
using StudentHouse.Models;
using StudentHouse.Services;

namespace StudentHouse.Controllers
{
    [Route("/[controller]")]
    public class MealsController : Controller
    {
        private readonly IMealService _mealService;
        private readonly IStudentService _studentService;

        public MealsController(
            IMealService mealService,
            IStudentService studentService)
        {
            _mealService = mealService;
            _studentService = studentService;
        }

        [HttpGet(Name = nameof(GetMealsAsync))]
        [ValidateModel]
        public async Task<IActionResult> GetMealsAsync(GetMealsParameters queryParameters, CancellationToken ct)
        {
            var meals = await _mealService.GetMealsAsync(null, null, queryParameters, ct);
            
            var collection = new Collection<MealResource>
            {
                Self = Link.ToCollection(nameof(GetMealsAsync)),
                Value = meals.Items.ToArray()
            };

            return Ok(collection);
        }

        [HttpGet("{mealId}", Name = nameof(GetMealByIdAsync))]
        [ValidateModel]
        public async Task<IActionResult> GetMealByIdAsync(GetMealByIdParameters routeParameters, CancellationToken ct)
        {
            if (routeParameters.MealId == Guid.Empty) return NotFound();

            var meal = await _mealService.GetMealAsync(routeParameters.MealId, ct);
            if (meal == null) return NotFound();

            return Ok(meal);
        }

        [HttpGet("{mealId}/guests", Name = nameof(GetMealGuestsByIdAsync))]
        [ValidateModel]
        public async Task<IActionResult> GetMealGuestsByIdAsync(GetMealByIdParameters routeParameters, GetStudentsParameters queryParameters, CancellationToken ct)
        {
            var mealGuests = await _studentService.GetStudentsAsync(routeParameters.MealId, queryParameters, ct);

            var collection = new Collection<StudentResource>
            {
                Self = Link.ToCollection(
                    nameof(GetMealGuestsByIdAsync),
                    new GetMealByIdParameters { MealId = routeParameters.MealId }),
                Value = mealGuests.Items.ToArray()
            };

            return Ok(collection);
        }

        [HttpPost(Name = nameof(PostMealAsync))]
        [ValidateModel]
        public async Task<IActionResult> PostMealAsync([FromBody] MealEntity mealEntity, CancellationToken ct)
        {
            var mealResource = await _mealService.PostMealAsync(mealEntity, ct);
                
            return Ok(mealResource);
        }
    }
}
