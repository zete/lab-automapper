using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabAutomapper.DTOs
{
    public class EmployeeDTO
    {
        public string FullName { get; set; }

        public DateTime Birthday { get; set; }
        public DepartmentDTO Department { get; set; }

    }
}
