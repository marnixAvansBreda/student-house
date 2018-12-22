using AutoMapper;
using StudentHouse.Controllers;
using StudentHouse.Models;

namespace StudentHouse.Infrastructure
{
    public class DefaultAutomapperProfile : Profile
    {
        public DefaultAutomapperProfile()
        {
            CreateMap<MealEntity, MealResource>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(
                    nameof(MealsController.GetMealByIdAsync),
                    new GetMealByIdParameters { MealId = src.Id })))
                .ForMember(dest => dest.Guests, opt => opt.MapFrom(src => Link.ToCollection(
                    nameof(MealsController.GetMealGuestsByIdAsync),
                    new GetMealByIdParameters { MealId = src.Id })))
                .ForMember(dest => dest.Chef, opt => opt.MapFrom(src => Link.To(
                    nameof(StudentsController.GetStudentByIdAsync),
                    new GetStudentByIdParameters { StudentId = src.ChefId } )));

            CreateMap<StudentEntity, StudentResource>()
                .ForMember(dest => dest.Self, opt => opt.MapFrom(src => Link.To(
                    nameof(StudentsController.GetStudentByIdAsync),
                    new GetStudentByIdParameters { StudentId = src.Id })))
                .ForMember(dest => dest.MealsAsChef, opt => opt.MapFrom(src => Link.ToCollection(
                    nameof(StudentsController.GetStudentMealsAsChefByIdAsync),
                    new GetStudentByIdParameters { StudentId = src.Id })))
                .ForMember(dest => dest.MealsAsGuest, opt => opt.MapFrom(src => Link.ToCollection(
                    nameof(StudentsController.GetStudentMealsAsGuestByIdAsync),
                    new GetStudentByIdParameters { StudentId = src.Id })));
        }
    }
}
