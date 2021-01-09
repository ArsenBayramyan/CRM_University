using CRM_University.Core.Interfaces;
using CRM_University.Data.Context;
using CRM_University.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private ApplicationDBContext _context;
        public StudentRepository(ApplicationDBContext context)
        {
            this._context = context;
        }
        public Student GetByID(int id)
        {
            var student = this._context.Students.Where(s => s.StudentId == id).FirstOrDefault();
            return student;
        }

        public IEnumerable<Student> List()
        {
            return this._context.Students;
        }
    }
}
