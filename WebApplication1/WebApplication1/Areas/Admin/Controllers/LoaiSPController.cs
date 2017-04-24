using MobileShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Bus;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class LoaiSPController : Controller
    {
        // GET: Admin/LoaiSP
        public ActionResult Index(int Page = 1)
        {
            var DsLoaiSP = LoaiBus.PageDanhSach(Page,10);
            return View(DsLoaiSP);
        }

        // GET: Admin/LoaiSP/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/LoaiSP/Create
        public ActionResult Create()
        {
            List<CustomDropDownList> BiXoa = new List<CustomDropDownList>()
            {
                new CustomDropDownList {Text="Không Xóa",Value=0 },
                new CustomDropDownList {Text="Xóa",Value=1 }
            };
            ViewBag.BiXoa = new SelectList(BiXoa, "Value", "Text");
            return View();
        }

        // POST: Admin/LoaiSP/Create
        [HttpPost]
        public ActionResult Create(LoaiSP LoaiSP)
        {
            try
            {
                // TODO: Add insert logic here
                LoaiBus.Them(LoaiSP);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/LoaiSP/Edit/5
        public ActionResult Edit(int id)
        {
            var rs = LoaiBus.ChiTiet(id);
            List<CustomDropDownList> BiXoa = new List<CustomDropDownList>()
            {
                new CustomDropDownList {Text="Không Xóa",Value=0 },
                new CustomDropDownList {Text="Xóa",Value=1 }
            };
            ViewBag.BiXoa = new SelectList(BiXoa, "Value", "Text");
            return View(rs);
        }

        // POST: Admin/LoaiSP/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, LoaiSP LoaiSP)
        {
            try
            {
                // TODO: Add update logic here
                LoaiBus.Sua(LoaiSP);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/LoaiSP/Delete/5
        public ActionResult Delete(int id)
        {
            var rs = LoaiBus.ChiTiet(id);
            return View(rs);
        }

        // POST: Admin/LoaiSP/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                LoaiBus.Xoa(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Deleted(int Page = 1)
        {
            var rs = LoaiBus.PageDanhSachDaXoa(Page,10);
            return View(rs);
        }
        public ActionResult Restore(int id)
        {
            LoaiBus.KhoiPhuc(id);
            return RedirectToAction("Deleted");
        }
    }
}
