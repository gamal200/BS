using BS.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Service
{
    public interface IEmployeeService
    {
        BSResposeDTO AddEmployee(CarCreationDTO model);
        BSResposeDTO EditEmployee(CarUpdateDTO model);
        List<CarListDTO> ListEmployees();
        BSResposeDTO DeleteEmployee(int CarId);
    }
}
