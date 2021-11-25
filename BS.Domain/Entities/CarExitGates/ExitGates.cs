using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Domain
{
    public class ExitGates:BaseEntity
    {
        public virtual Car Car { get; set; }
        public int CarId { get; set; }
        //public int GateId { get; set; }
        //public virtual Gate Gate { get; set; }

        public string GateType { get; set; }
    }
}
