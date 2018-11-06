namespace Fuzion.UI.Core.Models
{
    public class HardwareTypeOS
    {
        public int HardwareTypeId { get; set; }
        public HardwareType HardwareType { get; set; }

        public int OSId { get; set; }
        public OS OS { get; set; }
    }
}