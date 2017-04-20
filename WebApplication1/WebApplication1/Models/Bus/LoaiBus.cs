using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileShopConnection;
namespace WebApplication1.Models.Bus
{
    public class LoaiBus
    {
        public static IEnumerable<MobileShopConnection.LoaiSP> DanhSach()
        {
            var db = new MobileShopConnectionDB();
            return db.Query<MobileShopConnection.LoaiSP>("select * from LoaiSP where BiXoa<>1");
        }
    }
}