using AutoMapper;
using RestaurantAPI.Models;

namespace RestaurantAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserModel, Entities.User>(MemberList.Source);
            CreateMap<Entities.User, UserModel>().ForMember(x => x.Password, opt => opt.Ignore());
            CreateMap<CompanyDTO, Entities.Company>(MemberList.Source);
            CreateMap<IngredientDTO, Entities.Ingredient>(MemberList.Source);
            CreateMap<Entities.Ingredient, IngredientDTO>(MemberList.Source);
            CreateMap<Entities.User, UserAuthModel>(MemberList.Source);
            CreateMap<Entities.Dish, DishDTO>().ReverseMap();
            CreateMap<Entities.Menu, MenuDTO>(MemberList.Source);
            CreateMap<MenuDTO, Entities.Menu>(MemberList.Source);
            CreateMap<Entities.DishCalendar, DishCalendarDTO>(MemberList.Source);
            CreateMap<DishCalendarDTO, Entities.DishCalendar>(MemberList.Source);
            CreateMap<Entities.DishCalendar, DishCalendarDateDTO>(MemberList.Source);
            CreateMap<DishCalendarDateDTO, Entities.DishCalendar>(MemberList.Source);
        }
    }
}
