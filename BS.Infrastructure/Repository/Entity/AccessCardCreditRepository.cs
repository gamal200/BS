using BS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BS.Infrastructure
{
    public class AccessCardCreditRepository:BaseRepository<AccessCardCredit>,IAccessCardCreditRepository
    {

        public int GetTotalCredit(int AccessCardId)
        {
            int listofPlus = Find(e => !e.IsDeleted && e.AccessCardId == AccessCardId && e.CostType == CostTypeEnum.Plus.ToString()).Select(e => e.CostValue).Sum();
            int listofminus = Find(e => !e.IsDeleted && e.AccessCardId == AccessCardId && e.CostType == CostTypeEnum.Minus.ToString()).Select(e => e.CostValue).Sum();
            return listofPlus - listofminus;
        }
    }
}
