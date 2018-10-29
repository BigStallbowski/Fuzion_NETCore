using System.Collections.Generic;

namespace Fuzion.Core.Models
{
    public class Hardware : BaseModel
    {
        public int Id { get; set; }
        public string AssetNumber { get; set; }
        public string SerialNumber { get; set; }
        public byte IsAssigned { get; set; }
        public byte IsRetired { get; set; }
        public string AssignedTo { get; set; }
        public HardwareType HardwareType { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Model Model { get; set; }
        public OS OS { get; set; }
        public Purpose Purpose { get; set; }

        public List<Note> Notes { get; set; }
        public List<AssignmentHistory> AssignmentHistory { get; set; }
    }
}