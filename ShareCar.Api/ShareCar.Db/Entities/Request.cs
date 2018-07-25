﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShareCar.Db.Entities
{
    public class Request
    {
        public int RequestId { get; set; }
        public string PassengerEmail { get; set; }
        public string DriverEmail { get; set; }
        public int AddressId { get; set; }
        public Status Status { get; set; }
        
        [ForeignKey("PassengerEmail")]
        public virtual User Passenger { get; set;}
        [ForeignKey("DriverEmail")]
        public virtual User Driver { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address RequestAddress { get; set; }
    }
    public enum Status
    {
        WAITING,
        ACCEPTED,
        DENIED
    }
}
