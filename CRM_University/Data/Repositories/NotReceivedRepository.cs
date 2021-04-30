using CRM_University.Core.Interfaces;
using CRM_University.Data.Contexts;
using CRM_University.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Repositories
{
    public class NotReceivedRepository : IRepository<NotReceived>
    {
        private readonly ApplicationDBContext _context;
        public NotReceivedRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public NotReceived GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NotReceived> List()
        {
            return _context.NotReceiveds;
        }
    }
}
