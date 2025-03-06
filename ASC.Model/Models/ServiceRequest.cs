﻿using ASC.Model.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Model.Models
{
    public class ServiceRequest : BaseEntity, IauditTracker
    {
        public ServiceRequest() { }
        public ServiceRequest(string email)
        {
            this.Rowkey = Guid.NewGuid().ToString();
            this.Partitionkey = email;
        }
        public string VehicleName { get; set; }
        public string VehicleType { get; set; }
        public string Status { get; set; }
        public string RequestedServices { get; set; } 
        public DateTime? RequestedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string ServiceEngineer { get; set; } 
    }
}
