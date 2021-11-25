using BS.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BS.Service.DTOs
{
    public class EmployeeCreationDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public EmployeePositionEnum Position { get; set; }
        [Required]
        public int Age { get; set; }


    }
}
