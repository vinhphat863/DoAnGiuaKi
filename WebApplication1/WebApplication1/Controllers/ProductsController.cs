using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Bus;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products

        public ActionResult Index(int Page = 1)
        {
            var DsSanPham = SanPhamBus.PageDanhSach(Page, 8);
            return View(DsSanPham);
        }

        // GET: SanPham/Details/5
        public ActionResult Details(int id)
        {
            var ChiTiet = SanPhamBus.ChiTiet(id);
            return View(ChiTiet);
        }
    }
}