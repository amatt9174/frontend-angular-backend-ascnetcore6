using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;
using API.Dtos;
using AutoMapper;
using API.Errors;
using Microsoft.AspNetCore.Http;
using API.Helpers;

namespace API.Controllers
{
    public class AttachmentsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Member> _membersRepo;
        private readonly IGenericRepository<Attachment> _attachmentsRepo;
        public AttachmentsController(IGenericRepository<Member> membersRepo,
            IGenericRepository<Attachment> attachmentsRepo, IMapper mapper)
        {
            _mapper = mapper;
            _attachmentsRepo = attachmentsRepo;
            _membersRepo = membersRepo;
        }

        [Cached(600)]
        [HttpGet]
        public async Task<ActionResult<Pagination<AttachmentToReturnDto>>> GetAttachments(
            [FromQuery]AttachmentSpecParams attachmentParams)
        {
            var spec = new AttachmentsWithMembersSpecification(attachmentParams);

            var countSpec = new AttachmentsWithFiltersForCountSpecification(attachmentParams);

            var totalItems = await _attachmentsRepo.CountAsync(countSpec);

            var attachments = await _attachmentsRepo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Attachment>, IReadOnlyList<AttachmentToReturnDto>>(attachments); 

            return Ok(new Pagination<AttachmentToReturnDto>(attachmentParams.PageIndex, attachmentParams.PageSize, totalItems, data));
        }
        
        [Cached(600)]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<AttachmentToReturnDto>> GetAttachment(Guid id)
        {
            var spec = new AttachmentsWithMembersSpecification(id);

            var attachment = await _attachmentsRepo.GetEntityWithSpec(spec);

            if (attachment == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return _mapper.Map<Attachment, AttachmentToReturnDto>(attachment);
        }

        [Cached(600)]
        [HttpGet("groups")]
        public async Task<ActionResult<IReadOnlyList<GroupToReturnDto>>> GetGroups(
            [FromQuery]GroupSpecParams groupParams)
        {
            var spec = new GroupsWithMembersSpecification(groupParams);

            var attachments = await _attachmentsRepo.ListAsync(spec);

            var groupsDistinct = attachments.Select(x => new {x.AGroup}).Distinct();

            return Ok(groupsDistinct);
        }

        [Cached(600)]
        [HttpGet("members/{id}")]
        public async Task<Member> GetMember(Guid id)
        {
            return await _membersRepo.GetByIdAsync(id);
        }
    }
}