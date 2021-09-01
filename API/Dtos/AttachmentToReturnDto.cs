using System;

namespace API.Dtos
{
    public class AttachmentToReturnDto
    {
        public string AtId { get; set; } 
        public string TKey { get; set; }
        public string EMail { get; set; }
        public string MId { get; set; }
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