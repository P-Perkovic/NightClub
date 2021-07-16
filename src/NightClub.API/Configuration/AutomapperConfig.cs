using AutoMapper;
using NightClub.API.Dtos.Article;
using NightClub.API.Dtos.Category;
using NightClub.API.Dtos.Table;
using NightClub.API.Dtos.User;
using NightClub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        }
    }
}
