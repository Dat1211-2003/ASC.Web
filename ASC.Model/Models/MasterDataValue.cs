using ASC.Model.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Model.Models
{
    public class MasterDataValue : BaseEntity, IauditTracker
    {
        public MasterDataValue() { }
        public MasterDataValue(string masterDataPartitionkey, string value)
        {
            this.Partitionkey = masterDataPartitionkey;
            this.Rowkey = Guid.NewGuid().ToString();
        }
        public bool IsActive { get; set; }
        public string Name { get; set; }
    }
}
