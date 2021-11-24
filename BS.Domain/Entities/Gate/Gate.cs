using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Domain
{
    public class Gate:BaseEntity
    {
        public Gate()
        {
            ExitGates = new HashSet<ExitGates>();
        }
       
        public string GateType { get; set; }
        public ICollection<ExitGates> ExitGates { get; set; }
    }
}
