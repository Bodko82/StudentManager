using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Models
{
    public class Speciality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Department> Departments { get; set; }

        public Speciality() { Departments = new HashSet<Department>(); }
    }
}
