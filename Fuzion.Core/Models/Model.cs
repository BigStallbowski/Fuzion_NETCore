using System.Collections.Generic;

namespace Fuzion.Core.Models
{
    public class Model : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Hardware> Hardware { get; set; }
    }
}