using System.Collections.Generic;

namespace Fuzion.UI.Core.Models
{
    public class OS : BaseModel
    {
        public string Name { get; set; }

        public List<HardwareTypeOS> HardwareTypes { get; set; }

        public List<Hardware> Hardware { get; set; }
    }
}