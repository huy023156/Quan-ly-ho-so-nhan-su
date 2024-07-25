using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RewardRepository : Repository<Reward>, IRewardRepository
    {
        private readonly ApplicationDbContext _db;
        public RewardRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(Reward reward)
        {
            _db.Update(reward);
        }
    }
}
