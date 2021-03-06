﻿using System.Collections.Generic;

namespace Fuzion.Core.Models
{
    public class Purpose : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Hardware> Hardware { get; set; }
    }
}