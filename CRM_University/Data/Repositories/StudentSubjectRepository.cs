using CRM_University.Core.Interfaces;
using CRM_University.Data.Contexts;
using CRM_University.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Repositories
{
    public class StudentSubjectRepository : IRepository<StudentSubject>
    {
        private ApplicationDBContext _context;
        public StudentSubjectRepository(ApplicationDBContext context)
        {
            this._context = context;
        }
        public StudentSubject GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentSubject> List()
        {
            return this._context.StudentSubjects;
        }
    }
}
