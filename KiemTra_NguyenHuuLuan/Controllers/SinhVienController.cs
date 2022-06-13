using KiemTra_NguyenHuuLuan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KiemTra_NguyenHuuLuan.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult Index()
        {
            var all_Sv= from sv in data.SinhViens select sv;
            return View(all_Sv);
        }
        public ActionResult Detail(string id)
        {
            var D_Sv = data.SinhViens.SingleOrDefault(m => m.MaSV == (id));
            return View(D_Sv);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien s)
        {
            var masv = collection["MaSV"];
            var hoten = collection["HoTen"];
            var gioitinh = collection["GioiTinh"];
            var hinh = collection["Hinh"];
            var ngaysinh =Convert.ToDateTime(collection["NgaySinh"]);
            var manganh = collection["MaNganh"];
            if (string.IsNullOrEmpty(masv) || string.IsNullOrEmpty(hoten) || string.IsNullOrEmpty(hinh)|| string.IsNullOrEmpty(manganh)|| string.IsNullOrEmpty(gioitinh))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.MaSV = masv;
                s.HoTen = hoten;
                s.GioiTinh = gioitinh;
                s.NgaySinh = ngaysinh;
                s.MaNganh = manganh;
                s.Hinh = hinh;
                data.SinhViens.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        public ActionResult Edit(string id)
        {
            var E_category = data.SinhViens.SingleOrDefault(m => m.MaSV == id);
            return View(E_category);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var sv = data.SinhViens.SingleOrDefault(m => m.MaSV == id);
            var hoten = collection["HoTen"];
            var gioitinh = collection["GioiTinh"];
            var ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);
            var hinh = collection["Hinh"];
            var manganh = collection["MaNganh"];
            sv.MaSV= id;
            if ( string.IsNullOrEmpty(hoten) || string.IsNullOrEmpty(hinh) || string.IsNullOrEmpty(manganh) || string.IsNullOrEmpty(gioitinh))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                sv.HoTen = hoten;
                sv.GioiTinh = gioitinh;
                sv.NgaySinh = ngaysinh;
                sv.Hinh =hinh;
                sv.MaNganh= manganh;
                UpdateModel(sv);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        public ActionResult Delete(string id)
        {
            var D_masv = data.SinhViens.SingleOrDefault(m => m.MaSV == id);
            return View(D_masv);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_masv = data.SinhViens.SingleOrDefault(m => m.MaSV == id);
            data.SinhViens.DeleteOnSubmit(D_masv);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}