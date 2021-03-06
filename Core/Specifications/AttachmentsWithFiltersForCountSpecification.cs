using Core.Entities;

namespace Core.Specifications
{
    public class AttachmentsWithFiltersForCountSpecification : BaseSpecification<Attachment>
    {
        public AttachmentsWithFiltersForCountSpecification(AttachmentSpecParams attachmentParams)
            : base(x =>
                (string.IsNullOrEmpty(attachmentParams.Search) || x.AType.ToLower().Contains(attachmentParams.Search)) &&
                (string.IsNullOrEmpty(attachmentParams.AGroup) || x.AGroup.ToLower().Contains(attachmentParams.AGroup)) &&
                (!attachmentParams.MId.HasValue || x.MId == attachmentParams.MId) &&
                (!attachmentParams.AtId.HasValue || x.AtId == attachmentParams.AtId)
            )
        {
        }
    }
}