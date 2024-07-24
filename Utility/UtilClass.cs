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
                //case ChiNhanhNganHang cn:
                //    return cn.NganHang.IsApplied && AreDependenciesValid(cn.XaPhuong, unitOfWork);
                default:
                    return false;
            }
        }

        public static string GetTaiSanCapPhatListByEmployeeId(int employeeId, IUnitOfWork unitOfWork)
        {
            var list = unitOfWork.EmployeeTaiSanCapPhatTable.GetAll(u => u.EmployeeId == employeeId, includeProperties: "TaiSanCapPhat").Select(t => t.TaiSanCapPhat.Name).ToArray();

            return string.Join(", ", list);
        }

        public static string GetPhuCapListByEmployeeId(int employeeId, IUnitOfWork unitOfWork)
        {
            HoSoLuong hoSoLuong = unitOfWork.HoSoLuongTable.Get(u => u.EmployeeId == employeeId);

            var list = unitOfWork.HoSoLuongPhuCapTable.GetAll(u => u.HoSoLuongId == hoSoLuong.Id, includeProperties: "PhuCap").Select(t => t.PhuCap.Name + ": " + t.Amount).ToArray();

            return string.Join(", ", list);
        }

        public static string GetCheDoPhucLoiListByEmployeeId(int employeeId, IUnitOfWork unitOfWork)
        {
            HoSoLuong hoSoLuong = unitOfWork.HoSoLuongTable.Get(u => u.EmployeeId == employeeId);

            var list = unitOfWork.HoSoLuongCheDoPhucLoiTable.GetAll(u => u.HoSoLuongId == hoSoLuong.Id, includeProperties: "CheDoPhucLoi").Select(t => t.CheDoPhucLoi.Name + ": " + t.Amount).ToArray();

            return string.Join(", ", list);
        }

        public static string GetDiaChiFull(int diaChiId, IUnitOfWork unitOfWork)
        {
            DiaChi diaChi = unitOfWork.DiaChiTable.Get(d => d.Id == diaChiId, includeProperties: "QuocGia,TinhThanh,QuanHuyen,XaPhuong");
            return diaChi.XaPhuong.Name + ", " + diaChi.QuanHuyen.Name + ", " + diaChi.TinhThanh.Name + ", " + diaChi.QuocGia.Name;   
        }

        public static string GetNameByTypeAndId(Type type, int id, IUnitOfWork unitOfWork)
        {
            if (type == typeof(QuocGia)) return unitOfWork.QuocGiaTable.Get(u => u.Id == id).Name;
            if (type == typeof(TinhThanh)) return unitOfWork.TinhThanhTable.Get(u => u.Id == id).Name;
            if (type == typeof(QuanHuyen)) return unitOfWork.QuanHuyenTable.Get(u => u.Id == id).Name;
			if (type == typeof(XaPhuong)) return unitOfWork.XaPhuongTable.Get(u => u.Id == id).Name;
			if (type == typeof(NganHang)) return unitOfWork.NganHangTable.Get(u => u.Id == id).Name;

			return "NOT FOUND";
		}
    }
}
