using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Attachment, AttachmentToReturnDto>()
                .ForMember(d => d.EMail, o => o.MapFrom(s => s.Member.EMail))
                .ForMember(d => d.ImageUrl, o => o.MapFrom(s => s.ALoc + s.AName));
            CreateMap<Member, MemberToReturnDto>();
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
            CreateMap<Address, AddressDto>().ReverseMap();

        }
    }
}