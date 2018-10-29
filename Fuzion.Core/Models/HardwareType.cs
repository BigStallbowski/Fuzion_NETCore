using System.Collections.Generic;
using Remotion.Linq.Parsing.Structure.NodeTypeProviders;

namespace Fuzion.Core.Models
{
    public class HardwareType : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Hardware> Hardware { get; set; }
    }
}