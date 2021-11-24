using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Domain
{
    public class AccessCardCredit:BaseEntity
    {
        public int AccessCardId { get; set; }
        public virtual AccessCard AccessCard { get; set; }
        public string AccessCardCreditType { get; set; }
        public string CostType { get; set; }
        public int CostValue { get; set; }
    }
}
