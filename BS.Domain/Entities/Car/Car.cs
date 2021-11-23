using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Domain
{
    public class Car:BaseEntity
    {
        public Car()
        {
            ExitGates = new HashSet<ExitGates>();
        }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public Model Model { get; set; }
        public int ModelId { get; set; }
        public string PlateNumber { get; set; }
        public int AccessCardId { get; set; }
        public AccessCard AccessCard { get; set; }
        public ICollection<ExitGates> ExitGates { get; set; }

    }
}
