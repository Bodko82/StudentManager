using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public virtual Speciality Speciality { get; set; }
    }
}
