using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Domain
{

    public class BussinessValidatorException : Exception
    {
        public ValidatorExceptionStatus ExceptionStatus { get; set; }
        public string ValidationMessage { get; set; }
    }
       
    

    public enum ValidatorExceptionStatus
    {
        NotFound = -1,
        Ok = 1,
        Error = -2,
        ValidationError = -3,
        NotAllowed = -4,
        Repeated = -5
    }
}
