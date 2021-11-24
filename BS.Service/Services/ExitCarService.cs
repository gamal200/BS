using BS.Domain;
using BS.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BS.Service
{
    public class ExitCarService : ICarService
    {


        private readonly ILogger<ExitCarService> _logger;
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IAccessCardRepository _AccessCardRepository;
        private readonly IAccessCardCreditRepository _AccessCardCreditRepository;
        private readonly ICarRepository _CarRepository;
        private readonly IExitGateRepository _exitGateRepository;
        public ExitCarService(ILogger<ExitCarService> logger, IEmployeeRepository EmployeeRepository, IAccessCardRepository AccessCardRepository,
            IAccessCardCreditRepository AccessCardCreditRepository, ICarRepository CarRepository, IExitGateRepository exitGateRepository)
        {
            _logger = logger;
            _EmployeeRepository = EmployeeRepository;
            _CarRepository = CarRepository;
            _AccessCardRepository = AccessCardRepository;
            _AccessCardCreditRepository = AccessCardCreditRepository;
            _exitGateRepository = exitGateRepository;
        }


        public BSResposeDTO ExitCar(int CardId,GateType gateType)
        {
            try
            {
                BSResposeDTO bSResposeDTO = new BSResposeDTO();
                Car car= _CarRepository.Find(e => !e.IsDeleted && e.Id == CardId,null, "AccessCard,AccessCard.AccessCardCredit").FirstOrDefault();
                if (car == null)
                    bSResposeDTO.AddError("Car Not Found !! ", "CarId", ValidatorExceptionStatus.NotFound.ToString());
                if (bSResposeDTO.HaveErrors)
                    return bSResposeDTO;
                _exitGateRepository.Add(new ExitGates { CarId = car.Id, CreationDate = DateTime.Now, GateType = gateType.ToString() });

                if (gateType == GateType.HighwayGate)
                {
                   ExitGates exitGates= _exitGateRepository.Find(e => !e.IsDeleted && e.CarId == CardId).OrderBy(e => e.CreationDate).LastOrDefault();
                   TimeSpan timeSpan = exitGates.CreationDate.Subtract(DateTime.Now);

                    if (timeSpan.Minutes>=0) 
                    {
                        _AccessCardCreditRepository.Add(new AccessCardCredit { AccessCardCreditType = AccessCardCreditTypeEnum.ExitGate.ToString(),
                            CostValue = 0, 
                            CostType = CostTypeEnum.Minus.ToString() ,CreationDate=DateTime.Now,AccessCardId=car.AccessCard.Id});
                    }

                    else
                    {
                         _AccessCardCreditRepository.Add(new AccessCardCredit
                        {
                            AccessCardCreditType = AccessCardCreditTypeEnum.ExitGate.ToString(),
                            CostValue = 4,
                            CostType = CostTypeEnum.Minus.ToString(),
                            CreationDate = DateTime.Now,
                            AccessCardId = car.AccessCard.Id
                        });
                    }
                }
                else
                {
                    _AccessCardCreditRepository.Add(new AccessCardCredit
                    {
                        AccessCardCreditType = AccessCardCreditTypeEnum.ExitGate.ToString(),
                        CostValue = 4,
                        CostType = CostTypeEnum.Minus.ToString(),
                        CreationDate = DateTime.Now,
                        AccessCardId = car.AccessCard.Id
                    });
                }

                int ExitisSaved = _exitGateRepository.Save();
                if (ExitisSaved < 1)
                    bSResposeDTO.AddError("error in save ExitGate ", "CarId", ValidatorExceptionStatus.Error.ToString());
                
                int CreditisSaved = _AccessCardCreditRepository.Save();
                if (ExitisSaved < 1)
                    bSResposeDTO.AddError("error in save Credit ", "CarId", ValidatorExceptionStatus.Error.ToString());
                
              

                bSResposeDTO.AddValue(_AccessCardCreditRepository.GetTotalCredit(car.AccessCardId));
                return bSResposeDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{location}", "EmployeeService-CarExit");
                throw ex;
            }
        }

      
    }
}
