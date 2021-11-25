using BS.Domain;
using BS.Domain.Enums.CarEnums;
using BS.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Service
{
    public class CarCreationDTO
    {
        public EmployeeCreationDTO Employee { get; set; }
        public CarBrandEnum Brand { get; set; }
        public CarModelEnum Model { get; set; }
        public string PlateNumber { get; set; }
        public AccessCardTypeEnum AccessCardType { get; set; }
    }
}
