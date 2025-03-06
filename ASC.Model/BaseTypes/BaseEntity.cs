using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Model.BaseTypes
{
    public class BaseEntity
    {
        public string Partitionkey { get; set; } 
        public string Rowkey { get; set; } 
        public bool IsDeleted { get; set; } 
        public DateTime CreatedDate { get; set; } 
        public DateTime UpdatedDate { get; set; } 
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public BaseEntity()
        {
            Partitionkey = Guid.NewGuid().ToString();
            Rowkey = Guid.NewGuid().ToString();
            CreatedDate = DateTime.UtcNow;
            UpdatedDate = DateTime.UtcNow;
            IsDeleted = false;
        }
    }
}
