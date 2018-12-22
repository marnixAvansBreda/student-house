using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StudentHouse.Controllers;
using StudentHouse.Models;

namespace StudentHouse.Services
{
    public class DefaultStudentService : IStudentService
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public DefaultStudentService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentResource> GetStudentAsync(Guid id, CancellationToken ct)
        {
            var entity = await _context
                .Students
                .SingleOrDefaultAsync(x => x.Id == id, ct);

            return _mapper.Map<StudentEntity, StudentResource>(entity);
        }

        public async Task<Page<StudentResource>> GetStudentsAsync(
            Guid? mealId,
            GetStudentsParameters queryParameters,
            CancellationToken ct)
        {
            IQueryable<StudentEntity> query = _context.Students;

            if (mealId != null)
            {
                query = query.Where(s => s.MealsAsGuest.Any(m => m.MealId == mealId));
            }
            
            if (queryParameters.Name != null)
            {
                query = query.Where(m => m.Name == queryParameters.Name);
            }

            if (queryParameters.EMail != null)
            {
                query = query.Where(m => m.EMail == queryParameters.EMail);
            }

            if (queryParameters.PhoneNumber != null)
            {
                query = query.Where(m => m.PhoneNumber == queryParameters.PhoneNumber);
            }

            var size = await query.CountAsync(ct);

            var items = await query
                .ProjectTo<StudentResource>()
                .ToArrayAsync(ct);

            return new Page<StudentResource>
            {
                Items = items,
                TotalSize = size
            };
        }
    }
}
