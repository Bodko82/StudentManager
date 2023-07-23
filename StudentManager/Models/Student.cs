using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentManager.Models
{
    public class Student
    {
        public int Id { get; set; }
        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
    }
}
