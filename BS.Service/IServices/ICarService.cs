using BS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Service
{
    public interface ICarService
    {
        BSResposeDTO ExitCar(int CarId,GateType GateType);
        
    }
}
