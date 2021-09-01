using System;

namespace API.Dtos
{
    public class MemberToReturnDto
    {
        public Guid MId { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }   
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EMail { get; set;}
        public int DriversLicenseNumber { get; set; }
        public string Status { get; set; }
    }
}