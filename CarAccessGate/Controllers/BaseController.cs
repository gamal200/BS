using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAccessGate.Controllers
{
    public class BaseController : ControllerBase
    {
        public string message { get; set; }
        public string code { get; set; }
    }
}
