using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Models
{
    public class Department
    {
        public int Id { get; set; }
        public virtual DepartmentType Type { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Speciality> Specialityes { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public Department() { Specialityes = new HashSet<Speciality>(); Employees = new HashSet<Employee>(); }
    }
}
