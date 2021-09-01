using Core.Entities;

namespace Core.Specifications
{
    public class MembersWithFiltersForCountSpecification : BaseSpecification<Member>
    {
        public MembersWithFiltersForCountSpecification(MemberSpecParams memberParams)
            : base(x =>
                (string.IsNullOrEmpty(memberParams.Search) || x.LastName.ToLower().Contains(memberParams.Search)) &&
                (!memberParams.MId.HasValue || x.MId == memberParams.MId)
            )
        {
        }
    }
}