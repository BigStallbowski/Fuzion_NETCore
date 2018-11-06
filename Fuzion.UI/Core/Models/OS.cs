using System.Collections.Generic;
using System.Linq;

namespace Fuzion.UI.Core.Models
{
    public class OS : BaseModel
    {
        public string Name { get; set; }

        public List<Hardware> Hardware { get; set; }
    }
}