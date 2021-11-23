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
        public string GateName { get; set; }
        public string GateType { get; set; }
        public string CostType { get; set; }
        public int CostValue { get; set; }

        public ICollection<ExitGates> ExitGates { get; set; }
    }
}
