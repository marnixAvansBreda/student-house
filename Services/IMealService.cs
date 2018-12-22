using System;
using System.Threading;
using System.Threading.Tasks;
using StudentHouse.Controllers;
using StudentHouse.Models;

namespace StudentHouse.Services
{
    public interface IMealService
    {
        Task<MealResource> GetMealAsync(Guid id, CancellationToken ct);

        Task<Page<MealResource>> GetMealsAsync(
            Guid? studentId,
            Guid? chefId,
            GetMealsParameters queryParameters,
            CancellationToken ct);

        Task<MealResource> PostMealAsync(MealEntity mealEntity, CancellationToken ct);
    }
}
