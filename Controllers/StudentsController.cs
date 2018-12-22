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
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IMealService _mealService;

        public StudentsController(
            IStudentService studentService,
            IMealService mealService)
        {
            _studentService = studentService;
            _mealService = mealService;
        }

        [HttpGet(Name = nameof(GetStudentsAsync))]
        [ValidateModel]
        public async Task<IActionResult> GetStudentsAsync(GetStudentsParameters queryParameters, CancellationToken ct)
        {
            var students = await _studentService.GetStudentsAsync(null, queryParameters, ct);

            var collection = new Collection<StudentResource>
            {
                Self = Link.ToCollection(nameof(GetStudentsAsync)),
                Value = students.Items.ToArray()
            };

            return Ok(collection);
        }

        [HttpGet("{studentId}", Name = nameof(GetStudentByIdAsync))]
        [ValidateModel]
        public async Task<IActionResult> GetStudentByIdAsync(GetStudentByIdParameters routeParameters, CancellationToken ct)
        {
            if (routeParameters.StudentId == Guid.Empty) return NotFound();

            var student = await _studentService.GetStudentAsync(routeParameters.StudentId, ct);
            if (student == null) return NotFound();

            return Ok(student);
        }

        [HttpGet("{studentId}/mealsAsGuest", Name = nameof(GetStudentMealsAsGuestByIdAsync))]
        [ValidateModel]
        public async Task<IActionResult> GetStudentMealsAsGuestByIdAsync(GetStudentByIdParameters routeParameters, GetMealsParameters queryParameters, CancellationToken ct)
        {
            if (routeParameters.StudentId == Guid.Empty) return NotFound();
            
            var guestMeals = await _mealService.GetMealsAsync(routeParameters.StudentId, null, queryParameters, ct);

            var collection = new Collection<MealResource>
            {
                Self = Link.ToCollection(
                    nameof(GetStudentMealsAsGuestByIdAsync),
                    new GetStudentByIdParameters { StudentId = routeParameters.StudentId }),
                Value = guestMeals.Items.ToArray()
            };

            return Ok(collection);
        }

        [HttpGet("{studentId}/mealsAsChef", Name = nameof(GetStudentMealsAsChefByIdAsync))]
        [ValidateModel]
        public async Task<IActionResult> GetStudentMealsAsChefByIdAsync(GetStudentByIdParameters routeParameters,GetMealsParameters queryParameters, CancellationToken ct)
        {
            if (routeParameters.StudentId == Guid.Empty) return NotFound();

            var chefMeals = await _mealService.GetMealsAsync(null, routeParameters.StudentId, queryParameters, ct);

            var collection = new Collection<MealResource>
            {
                Self = Link.ToCollection(
                    nameof(GetStudentMealsAsChefByIdAsync),
                    new GetStudentByIdParameters { StudentId = routeParameters.StudentId }),
                Value = chefMeals.Items.ToArray()
            };

            return Ok(collection);
        }
    }
}
