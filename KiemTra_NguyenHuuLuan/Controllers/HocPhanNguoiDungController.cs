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
            var all_hp = from hp in data.HocPhans select hp;
            return View(all_hp);
            
        }
        public List<hocphan> LayHocPhan()
        {
            List<hocphan> lstHocPhan = Session["hocphan"] as List<hocphan>;
            if (lstHocPhan == null)
            {
                lstHocPhan = new List<hocphan>();
                Session["hocphan"] = lstHocPhan;
            }
            return lstHocPhan;
        }
        public ActionResult HocPhan()
        {
            List<hocphan> lstGioHang = LayHocPhan();
            return View(lstGioHang);
        }
        public ActionResult ThemHocPhan(string id, string strURL)
        {
            List<hocphan> lstHocPhan = LayHocPhan();
            hocphan hocphan = lstHocPhan.Find(n => n.MaHP == id);
            if (hocphan == null)
            {
                hocphan = new hocphan(id);
                lstHocPhan.Add(hocphan);
                //return Redirect(strURL);
            }
            return Content("");
        }
    }
}