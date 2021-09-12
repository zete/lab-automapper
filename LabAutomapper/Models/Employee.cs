using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabAutomapper.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime Birthday { get; set; }
        public Department Department { get; set; }

    }
}
