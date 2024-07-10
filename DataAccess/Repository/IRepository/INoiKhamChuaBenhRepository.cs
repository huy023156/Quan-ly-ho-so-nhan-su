using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface INoiKhamChuaBenhRepository : IRepository<NoiKhamChuaBenh>
    {
        void Update(NoiKhamChuaBenh noiKhamChuaBenh);
    }
}
