using AMS.Entities;
using AMS.Model;
using AutoMapper;

namespace AMS.Repositories.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductGroup, CollectionViewModel>().ReverseMap();
            CreateMap<Product, CollectionViewModel>().ReverseMap();
        }
    }
}
