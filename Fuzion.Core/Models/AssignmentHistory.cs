using System.Collections.Generic;

namespace Fuzion.Core.Models
{
    public class AssignmentHistory : BaseModel
    {
        public int Id { get; set; }
        public int Body { get; set; }

        public List<Hardware> Hardware { get; set; }
    }
}