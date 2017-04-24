using MobileShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Bus;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class HangSPController : Controller
    {
        // GET: Admin/HangSP
        public ActionResult Index(int Page = 1)
        {
            var DsHangSP = HangBus.PageDanhSach(Page, 10);
            return View(DsHangSP);
        }

        // GET: Admin/HangSP/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/HangSP/Create
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

        // POST: Admin/HangSP/Create
        [HttpPost]
        public ActionResult Create(HangSP HangSP)
        {
            try
            {
                // TODO: Add insert logic here
                HangBus.Them(HangSP);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/HangSP/Edit/5
        public ActionResult Edit(int id)
        {
            var rs = HangBus.ChiTiet(id);
            List<CustomDropDownList> BiXoa = new List<CustomDropDownList>()
            {
                new CustomDropDownList {Text="Không Xóa",Value=0 },
                new CustomDropDownList {Text="Xóa",Value=1 }
            };
            ViewBag.BiXoa = new SelectList(BiXoa, "Value", "Text");
            return View(rs);
        }

        // POST: Admin/HangSP/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, HangSP HangSP)
        {
            try
            {
                // TODO: Add update logic here
                HangBus.Sua(HangSP);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/HangSP/Delete/5
        public ActionResult Delete(int id)
        {
            var rs = HangBus.ChiTiet(id);
            return View(rs);
        }

        // POST: Admin/HangSP/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                HangBus.Xoa(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Deleted(int Page = 1)
        {
            var DsHangSP = HangBus.PageDanhSachDaXoa(Page,10);
            return View(DsHangSP);
        }
        public ActionResult Restore(int id)
        {
            HangBus.KhoiPhuc(id);
            return RedirectToAction("Deleted");
        }
    }
}
