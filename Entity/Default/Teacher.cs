using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Default
{
    public class Teacher
    {
        public Int64 ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Class> Classes { get; set; }

        public Teacher()
        {
            this.Classes = new HashSet<Class>();
        }
    }
}
