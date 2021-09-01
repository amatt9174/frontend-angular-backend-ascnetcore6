using System;
using Core.Entities;

namespace Core.Specifications
{
    public class MembersSpecification : BaseSpecification<Member>
    {
        public MembersSpecification(MemberSpecParams memberParams)
            : base(x =>
                (string.IsNullOrEmpty(memberParams.Search) ||
                    (x.FirstName.ToLower().Contains(memberParams.Search) ||
                     x.LastName.ToLower().Contains(memberParams.Search) &&
                (!memberParams.MId.HasValue || x.MId == memberParams.MId)))
            )
        {
            AddOrderBy(m => m.MId + m.LastName);
            ApplyPaging(memberParams.PageSize * (memberParams.PageIndex -1),
                memberParams.PageSize);
        
            if (!string.IsNullOrEmpty(memberParams.Sort))
            {
                switch (memberParams.Sort)
                {
                    case "emailAsc":
                        AddOrderBy(e => e.EMail);
                        break;
                    case "emailDesc":
                        AddOrderByDescending(e => e.EMail);
                        break;
                    case "dateofbirthAsc":
                        AddOrderBy(d => d.DateOfBirth);
                        break;
                    case "dateofbirthDesc":
                        AddOrderByDescending(d => d.DateOfBirth);
                        break;
                    default:
                        AddOrderBy(m => m.MId + m.LastName);
                        break;
                }
            }
        }
        public MembersSpecification(Guid id) : base(x => x.MId == id)
        {
        }
    }
}