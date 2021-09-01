using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDBContext _context;
        public MemberRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Member> GetMemberByIdAsync(Guid id)
        {
            return await _context.Members.FirstOrDefaultAsync(p => p.MId == id);
        }

        public async Task<IReadOnlyList<Member>> GetMembersAsync()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<IReadOnlyList<Attachment>> GetAttachmentsAsync()
        {
            return await _context.Attachments
                .Include(p => p.Member).ToListAsync();
        }
         public async Task<Attachment> GetAppAttachmentByIdAsync(Guid id)
        {
            return await _context.Attachments
                .Include(p => p.Member)
                .FirstOrDefaultAsync(p => p.AtId == id);
        }
   }
}