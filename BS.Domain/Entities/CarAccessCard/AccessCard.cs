using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Domain
{
    public class AccessCard:BaseEntity
    {
        public AccessCard()
        {
            AccessCardCredit = new HashSet<AccessCardCredit>();
        }
        public int CarId { get; set; }
        public virtual Car Car { get; set; }
        public ICollection<AccessCardCredit> AccessCardCredit { get; set; }
        public string AccessCardType { get; set; }
    }
}
