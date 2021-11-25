using BS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS.Infrastructure
{
    public class EmployeeRepository:BaseRepository<Employee>,IEmployeeRepository
    {
    }
}
