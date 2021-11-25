using BS.Domain;
using BS.Infrastructure;
using BS.Service.DTOs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BS.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ILogger<EmployeeService> _logger;
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IAccessCardRepository _AccessCardRepository;
        private readonly IAccessCardCreditRepository _AccessCardCreditRepository;
        private readonly IExitGateRepository _ExitGateRepository;
        private readonly ICarRepository _CarRepository;
        public EmployeeService(ILogger<EmployeeService> logger, IEmployeeRepository EmployeeRepository, IAccessCardRepository AccessCardRepository,
            IAccessCardCreditRepository AccessCardCreditRepository, ICarRepository CarRepository, IExitGateRepository ExitGateRepository)
        {
            _logger = logger;
            _EmployeeRepository = EmployeeRepository;
            _CarRepository = CarRepository;
            _AccessCardRepository = AccessCardRepository;
            _AccessCardCreditRepository = AccessCardCreditRepository;
            _ExitGateRepository = ExitGateRepository;
        }

        #region Add-New-Employee
        public BSResposeDTO AddEmployee(CarCreationDTO model)
        {
            try
            {
                BSResposeDTO bSResposeDTO = new BSResposeDTO();
                if (!IsValidPlateNumber(model.PlateNumber,null))
                    bSResposeDTO.AddError("Already Exists Plate Number !! ", "PlateNumber", ValidatorExceptionStatus.Repeated.ToString());
                if (bSResposeDTO.HaveErrors)
                    return bSResposeDTO;
                Employee employee = new Employee();
                MapAddEmployee(ref employee, model);
                _EmployeeRepository.Add(employee);
                int isSaved = _EmployeeRepository.Save();
                if (isSaved < 1)
                    bSResposeDTO.AddError("error in save Employee", "Employee", ValidatorExceptionStatus.Error.ToString());
                AccessCard accessCard = new AccessCard();
                MapAccessCard(ref accessCard, model);
                _AccessCardRepository.Add(accessCard);
                int AccessCardisSaved = _AccessCardRepository.Save();
                if (AccessCardisSaved < 1)
                    bSResposeDTO.AddError("error in save Access Card", "PlateNumber", ValidatorExceptionStatus.Error.ToString());
                Car car = new Car();
                MapCarCreation(ref car, employee.Id, accessCard.Id, model);
                _CarRepository.Add(car);
                int CarisSaved = _CarRepository.Save();
                if (CarisSaved < 1)
                    bSResposeDTO.AddError("error in save Car ", "PlateNumber", ValidatorExceptionStatus.Error.ToString());
                bSResposeDTO.AddValue(car.Id);
                return bSResposeDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{location}","EmployeeService-Add");
                throw ex;
            }
        }


        #endregion





        #region Edit-Employee
        public BSResposeDTO EditEmployee(CarUpdateDTO model)
        {
            try
            {
                BSResposeDTO bSResposeDTO = new BSResposeDTO();
                Car car = _CarRepository.Find(e => !e.IsDeleted && e.Id == model.CarId, null, "Employee,AccessCard,AccessCard.AccessCardCredit").FirstOrDefault();
                if (car == null)
                    bSResposeDTO.AddError("Car Not Found !! ", "CarId", ValidatorExceptionStatus.NotFound.ToString());
                if (bSResposeDTO.HaveErrors)
                    return bSResposeDTO;
                if (!IsValidPlateNumber(model.PlateNumber,car.Id))
                    bSResposeDTO.AddError("Already Exists Plate Number !! ", "PlateNumber", ValidatorExceptionStatus.Repeated.ToString());
                if (bSResposeDTO.HaveErrors)
                    return bSResposeDTO;
                
                MapEditEmployee(car.Employee, model);
                _EmployeeRepository.Update(car.Employee);
                int isSaved = _EmployeeRepository.Save();
                if (isSaved < 1)
                    bSResposeDTO.AddError("error in save Employee", "Employee", ValidatorExceptionStatus.Error.ToString());
                MapEditAccessCard(car.AccessCard, model);
                _AccessCardRepository.Update(car.AccessCard);
                int AccessCardisSaved = _AccessCardRepository.Save();
                if (AccessCardisSaved < 1)
                    bSResposeDTO.AddError("error in save Access Card", "PlateNumber", ValidatorExceptionStatus.Error.ToString());
                MapCarEdit(car, model);
                _CarRepository.Update(car);
                int CarisSaved = _CarRepository.Save();
                if (CarisSaved < 1)
                    bSResposeDTO.AddError("error in save Car ", "PlateNumber", ValidatorExceptionStatus.Error.ToString());
                return bSResposeDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{location}", "EmployeeService-Update");
                throw ex;
            }
        }


        #endregion


        #region List-All-Employess
        public List<CarListDTO> ListEmployees()
        {
            try
            {
                List<CarListDTO> carListDTO = new List<CarListDTO>();
                List<Car> _cars= _CarRepository.Find(e => !e.IsDeleted,null,"Employee,AccessCard").ToList();
                foreach (var car in _cars)
                {
                    carListDTO.Add(new CarListDTO { AccessCardType = car.AccessCard.AccessCardType, Credit = _AccessCardCreditRepository.GetTotalCredit(car.AccessCard.Id), EmployeeName = car.Employee.EmplyeeName, PlateNumber = car.PlateNumber });
                }
                return carListDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{location}", "EmployeeService-List");
                throw ex;
            }
        }


        #endregion


        #region DeleteEmployee
        public BSResposeDTO DeleteEmployee(int CarId)
        {
            try
            {
                BSResposeDTO bSResposeDTO = new BSResposeDTO();

                Car car= _CarRepository.Find(e => !e.IsDeleted && e.Id == CarId , null, "Employee,AccessCard,ExitGates,AccessCard.AccessCardCredit").FirstOrDefault();

                if (car == null)
                    bSResposeDTO.AddError("Car Not Found !! ", "CarId", ValidatorExceptionStatus.NotFound.ToString());
                if (bSResposeDTO.HaveErrors)
                    return bSResposeDTO;

                //delte employee
                car.Employee.IsDeleted = true;
                car.Employee.DeleteDate = DateTime.Now;
                _EmployeeRepository.Update(car.Employee);
                // delete access card 
                car.AccessCard.IsDeleted = true;
                car.AccessCard.DeleteDate = DateTime.Now;
                _AccessCardRepository.Update(car.AccessCard);

                //delete Access Card Credit
                if(car.AccessCard.AccessCardCredit.Where(e=>!e.IsDeleted) !=null && car.AccessCard.AccessCardCredit.Where(e => !e.IsDeleted).Count() > 0)
                {
                    foreach (var item in car.AccessCard.AccessCardCredit.Where(e => !e.IsDeleted))
                    {
                        item.IsDeleted = true;
                        item.DeleteDate = DateTime.Now;
                        _AccessCardCreditRepository.Update(item);
                    }
                }



                // delete 

                //ExitGate

                if (car.ExitGates.Where(e => !e.IsDeleted) != null && car.ExitGates.Where(e => !e.IsDeleted).Count() > 0)
                {
                    foreach (var item in car.ExitGates.Where(e => !e.IsDeleted))
                    {
                        item.IsDeleted = true;
                        item.DeleteDate = DateTime.Now;
                        _ExitGateRepository.Update(item);
                        
                    }
                }

                // delete car
                car.IsDeleted = true;
                car.DeleteDate = DateTime.Now;
                _CarRepository.Update(car);
                int CarisSaved = _CarRepository.Save();
                if (CarisSaved < 1)
                    bSResposeDTO.AddError("error in delete Car ", "PlateNumber", ValidatorExceptionStatus.Error.ToString());

                return bSResposeDTO;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{location}", "EmployeeService-Delete");
                throw ex;
            }
        }
        #endregion
        #region Private-Methods 
        private void MapAddEmployee(ref Employee employee, CarCreationDTO model)
        {
            employee.CreationDate = DateTime.Now;
            employee.EmplyeeName = model.Employee.Name;
            employee.EmployeePosition = model.Employee.Position.ToString();
            employee.Age = model.Employee.Age;
        }

        private void MapAccessCard(ref AccessCard accessCard, CarCreationDTO model)
        {
            accessCard.CreationDate = DateTime.Now;
            accessCard.AccessCardType = model.AccessCardType.ToString();
            if (model.AccessCardType == AccessCardTypeEnum.HighWayCard)
            {
                accessCard.AccessCardCredit.Add(new AccessCardCredit { CreationDate = DateTime.Now, AccessCardCreditType = AccessCardCreditTypeEnum.WelcomedCredit.ToString(),
                    CostType=CostTypeEnum.Plus.ToString(), CostValue=10});
            }
        }
        private void MapCarCreation(ref Car car,int EmployeeId,int AccessCardId, CarCreationDTO model)
        {

            car.Brand = model.Brand.ToString();
            car.CreationDate = DateTime.Now;
            car.Model = model.Model.ToString();
            car.PlateNumber = model.PlateNumber;
            car.EmployeeId = EmployeeId;
            car.AccessCardId = AccessCardId;
        }

        private bool IsValidPlateNumber(string PlateNumber,int? carId)
        {
            PlateNumber= PlateNumber.Trim();
            Car c =_CarRepository.Find(e => e.PlateNumber == PlateNumber &&!e.IsDeleted && carId !=null ? e.Id !=carId :true).FirstOrDefault();
            if (c != null)
                return false;
            return true;
        }


        private void MapEditEmployee(Employee employee, CarUpdateDTO model)
        {
            employee.UpdateDate = DateTime.Now;
            employee.IsUpdated = true;
            employee.EmplyeeName = model.Employee.Name;
            employee.EmployeePosition = model.Employee.Position.ToString();
            employee.Age = model.Employee.Age;
        }


        private void MapEditAccessCard(AccessCard accessCard, CarUpdateDTO model)
        {
            if(accessCard.AccessCardCredit.Where(e=>!e.IsDeleted) !=null && accessCard.AccessCardCredit.Where(e=>!e.IsDeleted).Count() > 0)
            {
                if (accessCard.AccessCardType == AccessCardTypeEnum.HighWayCard.ToString())
                {
                    if(model.AccessCardType != AccessCardTypeEnum.HighWayCard)
                    {
                       AccessCardCredit accesscardCredit= accessCard.AccessCardCredit.Where(e => e.AccessCardCreditType == AccessCardCreditTypeEnum.WelcomedCredit.ToString()).FirstOrDefault();
                       if(accesscardCredit != null)
                        {
                            accesscardCredit.IsDeleted = true;
                            accesscardCredit.DeleteDate = DateTime.Now;
                            _AccessCardCreditRepository.Update(accesscardCredit);
                        }
                    }
                }
            }
            accessCard.UpdateDate = DateTime.Now;
            accessCard.AccessCardType = model.AccessCardType.ToString();
            if (model.AccessCardType == AccessCardTypeEnum.HighWayCard && !accessCard.AccessCardCredit.Where(e=>!e.IsDeleted).Any(e=>e.AccessCardCreditType==AccessCardCreditTypeEnum.WelcomedCredit.ToString()))
            {
                accessCard.AccessCardCredit.Add(new AccessCardCredit { CreationDate = DateTime.Now, AccessCardCreditType = AccessCardCreditTypeEnum.WelcomedCredit.ToString() ,CostType=CostTypeEnum.Plus.ToString(),CostValue=10});
            }
        }


        private void MapCarEdit(Car car, CarUpdateDTO model)
        {

            car.Brand = model.Brand.ToString();
            car.CreationDate = DateTime.Now;
            car.Model = model.Model.ToString();
            car.PlateNumber = model.PlateNumber;
        }
        #endregion
    }
}
