using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MembersController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Member> _membersRepo;
        private readonly IGenericRepository<Attachment> _attachmentsRepo;
        public MembersController(IGenericRepository<Member> membersRepo,
            IGenericRepository<Attachment> attachmentsRepo, IMapper mapper)
        {
            _mapper = mapper;
            _attachmentsRepo = attachmentsRepo;
            _membersRepo = membersRepo;
        }
        [Cached(600)]
        [HttpGet]
        public async Task<ActionResult<Pagination<MemberToReturnDto>>> GetMembers(
            [FromQuery]MemberSpecParams memberParams)
        {
            var spec = new MembersSpecification(memberParams);

            var countSpec = new MembersWithFiltersForCountSpecification(memberParams);

            var totalItems = await _membersRepo.CountAsync(countSpec);

            var members = await _membersRepo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Member>, IReadOnlyList<MemberToReturnDto>>(members); 

            return Ok(new Pagination<MemberToReturnDto>(memberParams.PageIndex, memberParams.PageSize, totalItems, data));
        }
        [Cached(600)]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MemberToReturnDto>> GetMember(Guid id)
        {
            var spec = new MembersSpecification(id);

            var member = await _membersRepo.GetEntityWithSpec(spec);

            if (member == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return _mapper.Map<Member, MemberToReturnDto>(member);
        }
    }
}