using System;

namespace Fuzion.Core.Models
{
    public class BaseModel
    {
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}