using CRM_University.Core.Interfaces;
using CRM_University.Data.Context;
using CRM_University.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Repositories
{
    public class SubjectRepository : IRepository<Subject>
    {
        private ApplicationDBContext _context;
        public SubjectRepository(ApplicationDBContext context)
        {
           _context = context;
        }
        public Subject GetByID(int id)
        {
            var subject = this._context.Subjects.Where(s => s.SubjectId == id).FirstOrDefault();
            return subject;
        }

        public IEnumerable<Subject> List()
        {
            return this._context.Subjects;
        }
    }
}
