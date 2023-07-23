using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public int ExperienceYears { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public virtual User User { get; set; }
    }
}
