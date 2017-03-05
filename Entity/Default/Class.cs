using Entity.Default;
using System;
using System.Collections.Generic;

namespace Entity
{
    public class Class
    {
        public Int64 ID { get; set; }
        public string Name { get; set; }
        public int NumStudent { get; set; }
        public Int64 TeacherID { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}