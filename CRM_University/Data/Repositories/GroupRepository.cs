using CRM_University.Core.Interfaces;
using CRM_University.Data.Contexts;
using CRM_University.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Repositories
{
    public class GroupRepository : IRepository<Group>
    {
        private ApplicationDBContext _context;
        public GroupRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public Group GetByID(int id)
        {
            var group = this._context.Groups.Where(g => g.GroupId == id).FirstOrDefault();
            return group;
        }

        public IEnumerable<Group> List()
        {
            return this._context.Groups;
        }
    }
}
