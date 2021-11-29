using System;

namespace Core.Entities
{
    public class Member : BaseEntity
    {
        public Guid MId { get; set; }
        public Guid TKey { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }   

        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;
        public string EMail { get; set; }
        public int DriversLicenseNumber { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public string LocalTimezoneCreated { get; set; } =
            TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.UtcNow)
                ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName; 
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow;
        public string LocalTimezoneUpdated { get; set; }
    }
}