using BS.Domain;
using BS.Service;
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
    public class ExitGateController : BaseController
    {


        private readonly ILogger<ExitGateController> _logger;
        private readonly ICarService _Service;
        public ExitGateController(ILogger<ExitGateController> logger, ICarService Service)
        {
            _Service = Service;
            _logger = logger;
        }


        /// <summary>
        /// Simpulate API to  Exit A GATE 
        /// </summary>
        /// <param name="CarId"></param>
        /// <param name="gateType"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ExitGate")]
        public IActionResult ExitGate(int CarId, GateType gateType)
        {
            try
            {
                 BSResposeDTO outPut = _Service.ExitCar(CarId,gateType);
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
    }
}
