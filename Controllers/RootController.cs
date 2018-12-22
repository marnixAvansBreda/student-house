using Microsoft.AspNetCore.Mvc;
using StudentHouse.Models;

namespace StudentHouse.Controllers
{
    [Route("/")]
    public class RootController : Controller
    {
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var response = new RootResource
            {
                Self = Link.To(nameof(GetRoot)),
                Students = Link.ToCollection(nameof(StudentsController.GetStudentsAsync)),
                Meals = Link.ToCollection(nameof(MealsController.GetMealsAsync))
            };

            return Ok(response);
        }
    }
}
