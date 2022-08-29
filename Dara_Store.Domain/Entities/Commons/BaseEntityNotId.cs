﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dara_Store.Domain.Entities.Commons
{
    public class BaseEntityNotId
    {
        public DateTime InsertTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime? RemoveTime { get; set; }
    }
}
