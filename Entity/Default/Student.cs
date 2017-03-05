using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Student
    {
        public Int64 ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Int64 ClassID { get; set; }
        public virtual Class Class { get; set; }
    }
}
