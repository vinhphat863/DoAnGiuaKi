using MobileShopConnection;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Bus
{
    public class SanPhamBus
    {
        public static IEnumerable<MobileShopConnection.SanPham> DanhSach()
        {
            var db = new MobileShopConnectionDB();
            return db.Query<MobileShopConnection.SanPham>("select * from SanPham where BiXoa != 1");
        }

        public static Page<SanPham> PageDanhSachDaXoa(int PageNumber, int ItemPerPage)
        {
            var db = new MobileShopConnectionDB();
            return db.Page<SanPham>(PageNumber, ItemPerPage, "select * from SanPham where BiXoa = 1");
        }

        public static Page<SanPham> PageDanhSach(int PageNumber, int ItemPerPage)
        {
            var db = new MobileShopConnectionDB();
            return db.Page<SanPham>(PageNumber, ItemPerPage, "select * from SanPham where BiXoa != 1");
        }
        public static MobileShopConnection.SanPham ChiTiet(int id)
        {
            var db = new MobileShopConnectionDB();
            return db.SingleOrDefault<MobileShopConnection.SanPham>("select * from sanpham where MaSP=@0", id);
        }
        public static void Them(MobileShopConnection.SanPham sp)
        {
            var db = new MobileShopConnectionDB();
            db.Insert(sp);
        }
        public static void Xoa(int id)
        {
            var db = new MobileShopConnectionDB();
            var rs = Sql.Builder.Append("Exec XoaSanPham @0", id);
            db.Execute(rs);
        }
        public static void Sua(MobileShopConnection.SanPham sp)
        {
            var db = new MobileShopConnectionDB();
            db.Update(sp);
        }

        public static void KhoiPhuc(int id)
        {
            var db = new MobileShopConnectionDB();
            var rs = Sql.Builder.Append("Exec KhoiPhucSanPham @0", id);
            db.Execute(rs);
        }
    }
}