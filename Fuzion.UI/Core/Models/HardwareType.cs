using System.Collections.Generic;

namespace Fuzion.UI.Core.Models
{
    public class HardwareType : BaseModel
    {
        public string Name { get; set; }

        public List<HardwareTypeOS> OperatingSystems { get; set; }

        public List<Hardware> Hardware { get; set; }
    }
}