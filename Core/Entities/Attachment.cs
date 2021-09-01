using System;

namespace Core.Entities
{
    public class Attachment : BaseEntity
    {
        public Guid AtId { get; set; } 
        public Guid TKey { get; set; }
        public Member Member { get; set; }
        public Guid MId { get; set; }
        public string Status { get; set; }
        public string AName { get; set; }
        public string AGroup { get; set; }
        public string ALoc { get; set; }
        public string AType { get; set; }
        public string AFormat { get; set; }
        public string ADesc { get; set; }
        public string ACypher { get; set; }
        public string Remarks { get; set; }
        public string Usage { get; set; }
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.UtcNow;
        public string LocalTimezoneCreated { get; set; } =
            TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName; 
        public DateTimeOffset DateUpdated { get; set; } = DateTimeOffset.UtcNow;
        public string LocalTimezoneUpdated { get; set; }
    }
}