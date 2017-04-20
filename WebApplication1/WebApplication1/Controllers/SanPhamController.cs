using MobileShopConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Bus;

namespace WebApplication1.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index()
        {
            var DsSanPham = SanPhamBus.DanhSach();
            return View(DsSanPham);
        }

        // GET: SanPham/Details/5
        public ActionResult Details(int id)
        {
            var ChiTiet = SanPhamBus.ChiTiet(id);
            return View(ChiTiet);
        }

        public ActionResult QuanLy()
        {
            var DsSanPham = SanPhamBus.DanhSach();
            return View(DsSanPham);
        }

        // GET: SanPham/Create
        public ActionResult Create()
        {
            List<CustomDropDownList> BiXoa = new List<CustomDropDownList>()
            {
                new CustomDropDownList {Text="Không Xóa",Value=0 },
                new CustomDropDownList {Text="Xóa",Value=1 }
            };
            List<CustomDropDownList> TinhTrang = new List<CustomDropDownList>()
            {
                new CustomDropDownList {Text="Còn Hàng",Value=1 },
                new CustomDropDownList {Text="Hết Hàng",Value=0 }
            };
            ViewBag.TinhTrang = new SelectList(TinhTrang, "Value", "Text");
            ViewBag.BiXoa = new SelectList(BiXoa, "Value", "Text");
            ViewBag.MaHang = new SelectList(HangBus.DanhSach(), "MaHang", "TenHang");
            ViewBag.MaLoai = new SelectList(LoaiBus.DanhSach(), "MaLoai", "TenLoai");
            return View();
        }

        // POST: SanPham/Create
        [HttpPost]
        public ActionResult Create(SanPham sp)
        {
            if (HttpContext.Request.Files.Count > 0)
            {
                var hpf = HttpContext.Request.Files[0];
                if (hpf.ContentLength > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    string fullPathWithFileName = "/ShopOnline/img/" + fileName + ".jpg";
                    hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                    sp.HinhAnh = fileName + ".jpg";

                }
            }
            SanPhamBus.Them(sp);
            return RedirectToAction("QuanLy");
        }

        // GET: SanPham/Edit/5
        public ActionResult Edit(int id)
        {
            var db = new MobileShopConnectionDB();
            var rs = db.SingleOrDefault<MobileShopConnection.SanPham>("select * from sanpham where MaSP=@0", id);
            List<CustomDropDownList> BiXoa = new List<CustomDropDownList>()
            {
                new CustomDropDownList {Text="Không Xóa",Value=0 },
                new CustomDropDownList {Text="Xóa",Value=1 }
            };
            List<CustomDropDownList> TinhTrang = new List<CustomDropDownList>()
            {
                new CustomDropDownList {Text="Còn Hàng",Value=1 },
                new CustomDropDownList {Text="Hết Hàng",Value=0 }
            };
            ViewBag.TinhTrang = new SelectList(TinhTrang, "Value", "Text");
            ViewBag.BiXoa = new SelectList(BiXoa, "Value", "Text");
            ViewBag.MaHang = new SelectList(HangBus.DanhSach(), "MaHang", "TenHang");
            ViewBag.MaLoai = new SelectList(LoaiBus.DanhSach(), "MaLoai", "TenLoai");
            return View(rs);
        }

        // POST: SanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SanPham sp)
        {
                // TODO: Add update logic here
                if (HttpContext.Request.Files.Count > 0)
                {
                    var hpf = HttpContext.Request.Files[0];
                    if (hpf.ContentLength > 0)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        string fullPathWithFileName = "/ShopOnline/img/" + fileName + ".jpg";
                        hpf.SaveAs(Server.MapPath(fullPathWithFileName));
                        sp.HinhAnh = fileName + ".jpg";

                    }
                }
                SanPhamBus.Sua(sp);
                return RedirectToAction("QuanLy");
            
        }

        // GET: SanPham/Delete/5
        public ActionResult Delete(int id)
        {
            var db = new MobileShopConnectionDB();
            var rs = db.SingleOrDefault<MobileShopConnection.SanPham>("select * from sanpham where MaSP=@0", id);
            return View(rs);
        }

        // POST: SanPham/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SanPham sp)
        {
            try
            {
                // TODO: Add delete logic here
                SanPhamBus.Xoa(id);
                return RedirectToAction("QuanLy");
            }
            catch
            {
                return View();
            }
        }
    }
}
