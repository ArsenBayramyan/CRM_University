using CRM_University.Core.Interfaces;
using CRM_University.Data.Contexts;
using CRM_University.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Repositories
{
    public class DiscountStudentRepository : IRepository<DiscountStudent>
    {
        private ApplicationDBContext _context;

        public DiscountStudentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public DiscountStudent GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DiscountStudent> List()
        {
            return this._context.DiscountStudents;
        }
    }
}
