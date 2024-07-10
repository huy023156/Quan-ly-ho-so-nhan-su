﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public IChucDanhRepository ChucDanhTable { get; }
        public IHopDongRepository HopDongTable { get; }
        public IQuocGiaRepository QuocGiaTable { get; }
        public ITinhThanhRepository TinhThanhTable { get; }
        public IQuanHuyenRepository QuanHuyenTable { get; }
        public IXaPhuongRepository XaPhuongTable { get; }
        public ITaiSanCapPhatRepository TaiSanCapPhatTable { get; }
        public IPhuCapRepository PhuCapTable { get; }
        public ICheDoPhucLoiRepository CheDoPhucLoiTable { get; }
        public INganHangRepository NganHangTable { get; }
        public IChiNhanhNganHangRepository ChiNhanhNganHangTable { get; }
        public IPhongBanRepository PhongBanTable { get; }
        public IPhongBanChucDanhRepository PhongBanChucDanhTable { get; }
        public IDiaChiRepository DiaChiTable { get; }
        public INoiKhamChuaBenhRepository NoiKhamChuaBenhTable { get; }

        void Save();
    }
}
