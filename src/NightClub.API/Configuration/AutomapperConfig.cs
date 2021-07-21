using AutoMapper;
using NightClub.API.Dtos.Admin;
using NightClub.API.Dtos.Article;
using NightClub.API.Dtos.Category;
using NightClub.API.Dtos.Reservation;
using NightClub.API.Dtos.Table;
using NightClub.API.Dtos.User;
using NightClub.Domain.Models;

namespace NightClub.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Category, CategoryResultDto>().ReverseMap();
            CreateMap<Table, TableResultDto>().ReverseMap();
            CreateMap<Article, ArticleAddDto>().ReverseMap();
            CreateMap<Article, ArticleEditDto>().ReverseMap();
            CreateMap<Article, ArticleResultDto>().ReverseMap();
            CreateMap<User, UserAddDto>().ReverseMap()
                .ForMember(u => u.StringId, opt => opt.MapFrom(ud => ud.Id))
                .ForMember(u => u.Id, opt => opt.Ignore());
            CreateMap<User, UserResultDto>().ReverseMap()
                .ForMember(u => u.StringId, opt => opt.MapFrom(ud => ud.Id))
                .ForMember(u => u.Id, opt => opt.Ignore());
            CreateMap<AdminConfig, AdminConfigResultDto>().ReverseMap()
                .ForMember(ac => ac.Id, opt => opt.Ignore());
            CreateMap<AdminConfig, AdminConfigUpdateDto>().ReverseMap()
                .ForMember(ac => ac.Id, opt => opt.Ignore());
            CreateMap<Reservation, ReservationResultDto>().ReverseMap();
            CreateMap<Reservation, ReservationAddDto>().ReverseMap();
        }
    }
}
