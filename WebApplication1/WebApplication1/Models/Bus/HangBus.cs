using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileShopConnection;

namespace WebApplication1.Models.Bus
{
    public class HangBus
    {
        public static IEnumerable<MobileShopConnection.HangSP> DanhSach()
        {
            var db = new MobileShopConnectionDB();
            return db.Query<MobileShopConnection.HangSP>("select * from HangSP where BiXoa<>1");
        }
    }
}