﻿using DataAccess.Data;
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
    public class QuocGiaRepository : Repository<QuocGia>, IQuocGiaRepository
    {
        private readonly ApplicationDbContext _db;
        public QuocGiaRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(QuocGia quocGia)
        {
            _db.Update(quocGia);
        }
    }
}
