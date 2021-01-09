using CRM_University.Core.Interfaces;
using CRM_University.Data.Context;
using CRM_University.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Repositories
{
    public class FacultyRepository : IRepository<Faculty>
    {
        private ApplicationDBContext _context;
        public FacultyRepository(ApplicationDBContext context)
        {
            this._context = context;
        }
        public Faculty GetByID(int id)
        {
            var faculty = this._context.Faculties.Where(f => f.FacultyId == id).FirstOrDefault();
            return faculty;
        }

        public IEnumerable<Faculty> List()
        {
            return this._context.Faculties;
        }
    }
}
