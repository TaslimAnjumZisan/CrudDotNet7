using AutoMapper;
using CrudDotNet7.Models;
using CrudDotNet7.ViewModel;

namespace CrudDotNet7.Map
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryIndexModel>().ReverseMap();
            CreateMap<Category, CategoryCreateModel>().ReverseMap();
            CreateMap<Category, CategoryEditModel>().ReverseMap();
            CreateMap<Category, CategoryDeleteModel>().ReverseMap();
        }
    }
}
