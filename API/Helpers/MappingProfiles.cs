using API.Dtos;
using AutoMapper;
using Core.Entities;

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
        }
    }
}