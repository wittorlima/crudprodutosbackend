using AutoMapper;
using CRUD.Application.DTOs;
using CRUD.Domain.Entities;

namespace CRUD.Application.Configurations.AutoMapper
{
    public class ProductMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Product, ProductDTO>()
                  .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                  .ForMember(x => x.Description, opt => opt.MapFrom(x => x.Description))
                  .ForMember(x => x.DatePurchased, opt => opt.MapFrom(x => x.DatePurchased))
                  .ForMember(x => x.Image, opt => opt.MapFrom(x => x.Image))
                  .ForMember(x => x.Origin, opt => opt.MapFrom(x => x.Origin))
                  .ForMember(x => x.Price, opt => opt.MapFrom(x => x.Price));
        }
    }
}