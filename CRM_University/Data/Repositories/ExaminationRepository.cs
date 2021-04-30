using CRM_University.Core.Interfaces;
using CRM_University.Data.Contexts;
using CRM_University.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Repositories
{
    public class ExaminationRepository : IRepository<Examination>
    {
        private ApplicationDBContext _context;
        public ExaminationRepository(ApplicationDBContext context)
        {
            this._context = context;
        }
        public Examination GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Examination> List()
        {
            return this._context.Examinations;
        }
    }
}
