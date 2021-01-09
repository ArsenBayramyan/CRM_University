using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Core.Interfaces
{
    interface IRepository<T>
    {
        T GetByID(int id);
        IEnumerable<T> List();
        
    }
}
