using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnel
{
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Male { get; set; }
        public Position Position { get; set; }
    }

    public class Position
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
}
