using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IDisciplinaryActionRepository : IRepository<DisciplinaryAction>
    {
        void Update(DisciplinaryAction disciplinaryAction);
    }
}
