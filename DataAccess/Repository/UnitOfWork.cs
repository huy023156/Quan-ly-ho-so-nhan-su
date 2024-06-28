﻿using DataAccess.Data;
using DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IChucDanhRepository ChucDanhTable { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            ChucDanhTable = new ChucDanhRepository(db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
