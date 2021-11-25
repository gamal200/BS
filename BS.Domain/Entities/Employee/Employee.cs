using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Domain
{
    public class Employee:BaseEntity
    {
        public string EmplyeeName { get; set; }
        public string EmployeePosition { get; set; }
        public int Age { get; set; }
        //public int CarId { get; set; }
        //public virtual Car Car { get; set; }
    }
}
