using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemTra_NguyenHuuLuan.Models
{
    public class hocphan : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        public string MaHP { get; set; }
        public string TenHP { get; set; }
        public int? SoTinChi { get; set; }
        public hocphan(string id)
        {
            MaHP = id;
            HocPhan sanpham = data.HocPhans.SingleOrDefault(n => n.MaHP == MaHP);
            TenHP = sanpham.TenHP;
            SoTinChi = sanpham.SoTinChi;
        }
    }
}