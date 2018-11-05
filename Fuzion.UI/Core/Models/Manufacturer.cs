using System.Collections.Generic;

namespace Fuzion.UI.Core.Models
{
    public class Manufacturer : BaseModel
    {
        public string Name { get; set; }

        public List<Hardware> Hardware { get; set; }
    }
}