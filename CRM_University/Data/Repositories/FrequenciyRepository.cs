using CRM_University.Core.Interfaces;
using CRM_University.Data.Contexts;
using CRM_University.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Repositories
{
    public class FrequenciyRepository : IRepository<Frequency>
    {
        private readonly ApplicationDBContext _context;
        public FrequenciyRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Frequency GetByID(int id)
        {
            var frequency = _context.Frequencies.Where(f => f.FrequencyId == id).FirstOrDefault();
            return frequency;
        }

        public IEnumerable<Frequency> List()
        {
            return _context.Frequencies;
        }
    }
}
