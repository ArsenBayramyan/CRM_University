using CRM_University.Core.Interfaces;
using CRM_University.Data.Context;
using CRM_University.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Repositories
{
    public class AssessmentRepository:IRepository<Assessment>
    {
        private ApplicationDBContext _context;
        public AssessmentRepository(ApplicationDBContext context)
        {
            this._context = context;
        }

        public Assessment GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Assessment> List()
        {
            return this._context.Assessments;
        }
    }
}
