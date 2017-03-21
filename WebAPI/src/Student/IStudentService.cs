using Entity;
using System.Collections.Generic;
using WebAPI.Common;

namespace WebAPI.src
{
    public interface IStudentService : IBaseService<Student>
    {
        bool IsExistedStudent(string userName);

        IList<Student> GetByName(string name);
    }
}