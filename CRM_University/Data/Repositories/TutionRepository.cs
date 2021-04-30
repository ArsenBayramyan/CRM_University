using CRM_University.Core.Interfaces;
using CRM_University.Data.Contexts;
using CRM_University.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Repositories
{
    public class TutionRepository : IRepository<Tuition>
    {
        private ApplicationDBContext _context { get; set; }
        public TutionRepository(ApplicationDBContext context)
        {
            this._context = context;
        }
        public Tuition GetByID(int id)
        {
            return null;
        }

        public IEnumerable<Tuition> List()
        {
            return this._context.Tuitions;
        }
    }
}
