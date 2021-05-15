using CRM_University.Core.Interfaces;
using CRM_University.Data.Contexts;
using CRM_University.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Repositories
{
    public class EmailLogRepository : IRepository<EmailLog>
    {
        private readonly ApplicationDBContext _context;
        public EmailLogRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public void Save(EmailLog emailLog)
        {
            _context.EmailLogs.Add(emailLog);
        }
        public EmailLog GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmailLog> List()
        {
            return _context.EmailLogs;
        }
    }
}
