using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class AttachmentUrlResolver : IValueResolver<Attachment, AttachmentToReturnDto, string>
    {
        private readonly IConfiguration _config;
        public AttachmentUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Attachment source, AttachmentToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.AName))
            {
                return _config["ApiUrl"] + source.AName;
            }
            return null;
        }
    }
}