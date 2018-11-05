using System.Collections.Generic;

namespace Fuzion.UI.Core.Models
{
    public class Model : BaseModel
    {
        public string Name { get; set; }
        
        public Manufacturer Manufacturer { get; set; }
        public List<Hardware> Hardware { get; set; }
    }
}