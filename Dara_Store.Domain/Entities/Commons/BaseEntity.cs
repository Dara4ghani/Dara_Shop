using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dara_Store.Domain.Entities.Commons
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime InsertTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool IsRemove { get; set; }
        public DateTime? RemoveTime { get; set; }
    }
    public abstract class BaseEntity : BaseEntity<long>
    {
    }
}
