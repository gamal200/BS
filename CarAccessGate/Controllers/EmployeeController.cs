using BS.Domain;
using BS.Service;
using BS.Service.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAccessGate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _Service;
        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService Service)
        {
            _Service = Service;
            _logger = logger;
        }

        /// <summary>
        /// Service to Add Employee With A Car 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddEmployee(CarCreationDTO model)
        {
            try
            {
                BSResposeDTO outPut = _Service.AddEmployee(model);
                if (outPut.HaveErrors)
                    return Problem(outPut.Stringfy());
                return Ok(outPut.Stringfy());
            }
            catch (BussinessValidatorException ex)
            {
                message = ex.ValidationMessage;
                code = ((int)ex.ExceptionStatus).ToString();
                _logger.LogError(ex.ValidationMessage);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                code = "-100";
                _logger.LogError(ex.Message);
            }
            Response.Headers.Add("ExceptionStatus", code);
            return Problem(message);

        }



        /// <summary>
        /// API - To Update Employee 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult UpdateEmployee(CarUpdateDTO model)
        {
            try
            {
                BSResposeDTO outPut = _Service.EditEmployee(model);
                if (outPut.HaveErrors)
                    return Problem(outPut.Stringfy());
                return Ok(outPut.Stringfy());
            }
            catch (BussinessValidatorException ex)
            {
                message = ex.ValidationMessage;
                code = ((int)ex.ExceptionStatus).ToString();
                _logger.LogError(ex.ValidationMessage);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                code = "-100";
                _logger.LogError(ex.Message);
            }
            Response.Headers.Add("ExceptionStatus", code);
            return Problem(message);

        }

        [HttpGet]
        [Route("EmployeeList")]
        public IActionResult EmployeeList()
        {
            try
            {
                List<CarListDTO> outPut = _Service.ListEmployees();
                return Ok(outPut);
            }
            catch (BussinessValidatorException ex)
            {
                message = ex.ValidationMessage;
                code = ((int)ex.ExceptionStatus).ToString();
                _logger.LogError(ex.ValidationMessage);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                code = "-100";
                _logger.LogError(ex.Message);
            }
            Response.Headers.Add("ExceptionStatus", code);
            return Problem(message);

        }



        [HttpDelete]
        [Route("DeleteEmployee")]
        public IActionResult DeleteEmployee(int CarId)
        {
            try
            {
                BSResposeDTO outPut = _Service.DeleteEmployee(CarId);
                if (outPut.HaveErrors)
                    return Problem(outPut.Stringfy());
                return Ok(outPut);
            }
            catch (BussinessValidatorException ex)
            {
                message = ex.ValidationMessage;
                code = ((int)ex.ExceptionStatus).ToString();
                _logger.LogError(ex.ValidationMessage);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                code = "-100";
                _logger.LogError(ex.Message);
            }
            Response.Headers.Add("ExceptionStatus", code);
            return Problem(message);

        }

    }
}
