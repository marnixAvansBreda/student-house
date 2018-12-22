using System;
using System.Threading;
using System.Threading.Tasks;
using StudentHouse.Controllers;
using StudentHouse.Models;

namespace StudentHouse.Services
{
    public interface IStudentService
    {
        Task<StudentResource> GetStudentAsync(Guid id, CancellationToken ct);

        Task<Page<StudentResource>> GetStudentsAsync(
            Guid? mealId,
            GetStudentsParameters queryParameters,
            CancellationToken ct);

    }
}
