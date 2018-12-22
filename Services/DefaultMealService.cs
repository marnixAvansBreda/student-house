using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StudentHouse.Controllers;
using StudentHouse.Models;

namespace StudentHouse.Services
{
    public class DefaultMealService : IMealService
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public DefaultMealService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MealResource> GetMealAsync(Guid id, CancellationToken ct)
        {
            var entity = await _context
                .Meals
                .SingleOrDefaultAsync(x => x.Id == id, ct);

            return _mapper.Map<MealEntity, MealResource>(entity);
        }

        public async Task<Page<MealResource>> GetMealsAsync(Guid? studentId, Guid? chefId,
            GetMealsParameters queryParameters, CancellationToken ct)
        {
            IQueryable<MealEntity> query = _context.Meals;

            if (chefId != null)
            {
                query = query.Where(m => m.ChefId == chefId);
            }

            if (studentId != null)
            {
                query = query.Where(m => m.Guests.Any(mg => mg.GuestId == studentId));
            }

            if (queryParameters.DateTime != DateTime.MinValue)
            {
                query = query.Where(m => DateTime.Compare(m.DateTime, queryParameters.DateTime) == 0);
            }

            if (queryParameters.Name != null)
            {
                query = query.Where(m => m.Name == queryParameters.Name);
            }

            if (queryParameters.Description != null)
            {
                query = query.Where(m => m.Description == queryParameters.Description);
            }

            if (queryParameters.ChefId != Guid.Empty)
            {
                query = query.Where(m => m.ChefId == queryParameters.ChefId);
            }

            if (!queryParameters.Price.Equals(-1))
            {
                query = query.Where(m => m.Price.Equals(queryParameters.Price));
            }

            if (queryParameters.MaxAmountOfGuests != -1)
            {
                query = query.Where(m => m.MaxAmountOfGuests == queryParameters.MaxAmountOfGuests);
            }

            var size = await query.CountAsync(ct);

            var items = await query
                .ProjectTo<MealResource>()
                .ToArrayAsync(ct);

            return new Page<MealResource>
            {
                Items = items,
                TotalSize = size
            };
        }

        public async Task<MealResource> PostMealAsync(MealEntity mealEntity, CancellationToken ct)
        {
            mealEntity.CreatedAt = DateTime.Now;

            var entity = await _context
                .Meals
                .AddAsync(mealEntity, ct);

            await _context.SaveChangesAsync(ct);

            return _mapper.Map<MealEntity, MealResource>(entity.Entity);
        }
    }
}
