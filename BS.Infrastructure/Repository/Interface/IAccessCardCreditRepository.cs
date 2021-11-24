using BS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Infrastructure
{
    public interface IAccessCardCreditRepository:IBaseRepository<AccessCardCredit>
    {
        int GetTotalCredit(int AccessCardId);
    }
}
