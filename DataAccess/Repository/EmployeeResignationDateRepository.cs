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
    public class EmployeeResignationDateRepository : Repository<EmployeeResignationDate>, IEmployeeResignationDateRepository
    {
        private readonly ApplicationDbContext _db;
        public EmployeeResignationDateRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(EmployeeResignationDate employeeResignationDate)
        {
            _db.Update(employeeResignationDate);
        }
    }
}
