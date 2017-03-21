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
        public string FullName { get; set; }
        public string FirstMidName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Int64 ClassID { get; set; }
        public Class Class { get; set; }
       
    }
}
