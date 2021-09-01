using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IMemberRepository
    {
        Task<Member> GetMemberByIdAsync(Guid id);
        Task<IReadOnlyList<Member>> GetMembersAsync();
        Task<Attachment> GetAppAttachmentByIdAsync(Guid id);
        Task<IReadOnlyList<Attachment>> GetAttachmentsAsync();
    }
}