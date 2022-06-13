using KiemTra_NguyenHuuLuan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemTra_NguyenHuuLuan.Controllers
{
    public class HocPhanController : Controller
    {
        // GET: HocPhan
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult Index()
        {
            var all_hp = from hp in data.HocPhans select hp;
            return View(all_hp);
        }
    }
}