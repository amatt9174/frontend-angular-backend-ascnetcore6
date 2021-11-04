using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class GroupsWithMembersSpecification : BaseSpecification<Attachment>
    {
        public GroupsWithMembersSpecification(GroupSpecParams groupParams)
            : base(x =>
                (string.IsNullOrEmpty(groupParams.Search) || x.AType.ToLower().Contains(groupParams.Search)) &&
                (string.IsNullOrEmpty(groupParams.AGroup) || x.AGroup.ToLower().Contains(groupParams.AGroup)) &&
                (!groupParams.MId.HasValue || x.MId == groupParams.MId) &&
                (!groupParams.AtId.HasValue || x.AtId == groupParams.AtId)
            )
        {
            AddInclude(m => m.Member);
            AddOrderBy(mat => mat.MId + mat.AType);
        
            if (!string.IsNullOrEmpty(groupParams.Sort))
            {
                switch (groupParams.Sort)
                {
                    case "agroupAsc":
                        AddOrderBy(g => g.AGroup);
                        break;
                    case "agroupDesc":
                        AddOrderByDescending(g => g.AGroup);
                        break;
                    case "atypeAsc":
                        AddOrderBy(t => t.AType);
                        break;
                    case "atypeDesc":
                        AddOrderByDescending(t => t.AType);
                        break;
                    default:
                        AddOrderBy(mat => mat.MId + mat.AType);
                        break;
                }
            }
        }
        // public AttachmentsWithimagesSpecification(Guid id) : base(at => at.AtId == id)
        // {
        //     AddInclude(m => m.image);
        // }
    }
}