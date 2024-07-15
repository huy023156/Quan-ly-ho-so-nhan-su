using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IHopDongDetailRepository : IRepository<HopDongDetail>
    {
        void Update(HopDongDetail hopDongDetail);
    }
}
