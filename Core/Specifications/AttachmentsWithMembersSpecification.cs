using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class AttachmentsWithMembersSpecification : BaseSpecification<Attachment>
    {
        public AttachmentsWithMembersSpecification(AttachmentSpecParams attachmentParams)
            : base(x =>
                (string.IsNullOrEmpty(attachmentParams.Search) || x.AType.ToLower().Contains(attachmentParams.Search)) &&
                (string.IsNullOrEmpty(attachmentParams.AGroup) || x.AGroup.ToLower().Contains(attachmentParams.AGroup)) &&
                (!attachmentParams.MId.HasValue || x.MId == attachmentParams.MId) &&
                (!attachmentParams.AtId.HasValue || x.AtId == attachmentParams.AtId)
            )
        {
            AddInclude(m => m.Member);
            AddOrderBy(mat => mat.MId + mat.AType);
            ApplyPaging(attachmentParams.PageSize * (attachmentParams.PageIndex -1),
                attachmentParams.PageSize);
        
            if (!string.IsNullOrEmpty(attachmentParams.Sort))
            {
                switch (attachmentParams.Sort)
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
        public AttachmentsWithMembersSpecification(Guid id) : base(at => at.AtId == id)
        {
            AddInclude(m => m.Member);
        }
    }
}