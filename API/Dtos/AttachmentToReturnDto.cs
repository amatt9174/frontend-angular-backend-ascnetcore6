using System;

namespace API.Dtos
{
    public class AttachmentToReturnDto
    {
        public Guid AtId { get; set; } 
        public Guid TKey { get; set; }
        public string EMail { get; set; }
        public Guid MId { get; set; }
        public string Status { get; set; }
        public string ImageUrl { get; set; }
        public string AGroup { get; set; }
        public string AType { get; set; }
        public string AFormat { get; set; }
        public string ADesc { get; set; }
        public string ACypher { get; set; }
        public string Remarks { get; set; }
        public string Usage { get; set; }
    }
}