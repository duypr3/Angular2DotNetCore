using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Base;

namespace WebAPI.src
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        private readonly IBaseRepository<Student> _studentRepo;
        public StudentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _studentRepo = UnitOfWork.GetRepository<Student>();
        }
        public bool IsExistedStudent(string userName)
        {
            return true;
        }
        public IList<Student> GetByName(string name)
        {
            return _studentRepo.Get(n => n.FirstMidName.Contains(name) || n.LastName.Contains(name)).ToList();
        }
    }
}
