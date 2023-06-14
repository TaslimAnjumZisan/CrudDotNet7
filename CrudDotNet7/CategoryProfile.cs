using AutoMapper;
using CrudDotNet7.Models;
using CrudDotNet7.ViewModel;

namespace CrudDotNet7
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
         
            CreateMap<Category, CategoryCreateModel>().ReverseMap();
           // CreateMap<Category, CategoryEditModel>().ReverseMap();
        }
    }
}
