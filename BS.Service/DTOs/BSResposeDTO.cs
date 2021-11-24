using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Service
{
    public class ErrorDTO
    {
        public string Error { get; set; }
        public string ErrorDetail { get; set; }
        public string ErrorCode { get; set; }
    };
    public class BSResposeDTO
    {
        public BSResposeDTO()
        {
            ErrorDTO = new List<ErrorDTO>();
        }
        public int Value { get; set; }
        public List<ErrorDTO> ErrorDTO { get; set; }
        public bool HaveErrors { get; set; }
        public void AddError(string errorMessage, string ErrorDetail, string ErrorCode)
        {
            ErrorDTO.Add(new Service.ErrorDTO() { Error = errorMessage, ErrorDetail = ErrorDetail, ErrorCode = ErrorCode });
            HaveErrors = true;
        }

        public void AddValue(int id)
        {
            Value = id;
        }
        public string Stringfy()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
