using DataAccess.Repository;
using DataAccess.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class UtilClass
    {
        public static bool AreDependenciesValid(Object obj, IUnitOfWork? unitOfWork)
        {
            switch (obj)
            {
                case TinhThanh tt:
                    return tt.QuocGia.IsApplied;
                case QuanHuyen qh:
                    if (!qh.TinhThanh.IsApplied)
                        return false;
                    var quocGia = unitOfWork.QuocGiaTable.Get(qg => qg.Id == qh.TinhThanh.QuocGiaId);
                    if (!quocGia.IsApplied)
                        return false;
                    return true;
                case XaPhuong xp:
                    var quanHuyen = unitOfWork.QuanHuyenTable.Get(q => q.Id == xp.QuanHuyenId);
                    if (!quanHuyen.IsApplied) return false;


                    var tinhThanh = unitOfWork.TinhThanhTable.Get(t => t.Id == quanHuyen.TinhThanhId, includeProperties: "QuocGia");
                    if (!tinhThanh.IsApplied) return false;
                    if (!tinhThanh.QuocGia.IsApplied) return false;
                    return true;
                case ChiNhanhNganHang cn:
                    return cn.NganHang.IsApplied && AreDependenciesValid(cn.XaPhuong, unitOfWork);
                default:
                    return false;
            }
        }
    }
}
