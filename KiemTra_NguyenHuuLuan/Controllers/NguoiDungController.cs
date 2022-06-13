using KiemTra_NguyenHuuLuan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemTra_NguyenHuuLuan.Controllers
{
    public class NguoiDungController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: NguoiDung
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var tendn = collection["USERNAME"];
            
            if (String.IsNullOrEmpty(tendn))
            {
                ViewData["Error1"] = "Phải nhập tên đăng nhập";
            }
            else
            {
                // Gán giá trị cho đối tượng được tạo mới(kh)
                SinhVien sv = data.SinhViens.SingleOrDefault(n => n.MaSV == tendn );
                if (sv != null )
                {
                    Session["TaiKhoanKH"] = sv;
                    return RedirectToAction("Index", "Home");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }
    }
}