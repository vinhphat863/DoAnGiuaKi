using MobileShopConnection;
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
            return db.Query<MobileShopConnection.SanPham>("select * from SanPham");
        }
        public static MobileShopConnection.SanPham ChiTiet(int id)
        {
            var db = new MobileShopConnectionDB();
            return db.SingleOrDefault<MobileShopConnection.SanPham>("select * from sanpham where MaSP=@0 and BiXoa != 1", id);
        }
    }
}