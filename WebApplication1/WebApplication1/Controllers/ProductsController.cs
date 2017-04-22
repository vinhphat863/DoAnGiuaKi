using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Bus;
using WebApplication1.Models.ViewModel;

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
            var ChiTietSP = SanPhamBus.ChiTiet(id);
            var ChiTietLoaiSP = LoaiBus.ChiTietViewModel(ChiTietSP.MaLoai);
            var ChitTietHangSP = HangBus.ChiTietViewModel(ChiTietSP.MaLoai);
            return View(new SanPhamViewModel() {LoaiSP=ChiTietLoaiSP,HangSP=ChitTietHangSP,SanPham=ChiTietSP });
        }
    }
}