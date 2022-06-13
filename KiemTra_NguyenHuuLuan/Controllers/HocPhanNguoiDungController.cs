using KiemTra_NguyenHuuLuan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemTra_NguyenHuuLuan.Controllers
{
    public class HocPhanNguoiDungController : Controller
    {
        // GET: HocPhanNguoiDung
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public List<HocPhan> LayHocPhan()
        {
            List<HocPhan> lstHocPhan = Session["hocphan"] as List<HocPhan>;
            if (lstHocPhan == null)
            {
                lstHocPhan = new List<HocPhan>();
                Session["hocphan"] = lstHocPhan;
            }
            return lstHocPhan;
        }
        public ActionResult HocPhan()
        {
            List<HocPhan> lstGioHang = LayHocPhan();
            

            return View(lstGioHang);
        }
    }
}