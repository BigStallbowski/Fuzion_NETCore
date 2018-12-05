namespace Fuzion.UI.Core.Models
{
    public class AssignmentHistory : BaseModel
    {
        public string Body { get; set; }

        public int HardwareId { get; set; }
        public Hardware Hardware { get; set; }
    }
}