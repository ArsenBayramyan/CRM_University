using CRM_University.Core.Interfaces;
using CRM_University.Data.Contexts;
using CRM_University.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Repositories
{
    public class UnpaidStudentsRepository : IRepository<SentEmails>
    {
        private ApplicationDBContext _context;
        public UnpaidStudentsRepository(ApplicationDBContext context)
        {
            this._context = context;
        }
        public SentEmails GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(SentEmails entity)
        {
            this._context.Add(entity);
            this._context.SaveChanges();
        }

        public IEnumerable<SentEmails> List()
        {
            return this._context.UnpaidStudents;
        }
    }
}
