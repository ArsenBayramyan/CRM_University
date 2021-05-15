using CRM_University.Core.Interfaces;
using CRM_University.Data.Contexts;
using CRM_University.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Repositories
{
    public class ReprimandedStudentRepository : IRepository<ReprimandedStudent>
    {
        private ApplicationDBContext _context;
        public ReprimandedStudentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public void Save(ReprimandedStudent reprimandedStudent)
        {
            _context.ReprimandedStudents.Add(reprimandedStudent);
        }

        public ReprimandedStudent GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReprimandedStudent> List()
        {
            return _context.ReprimandedStudents;
        }
    }
}
