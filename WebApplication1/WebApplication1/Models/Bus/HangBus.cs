using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileShopConnection;
using PetaPoco;

namespace WebApplication1.Models.Bus
{
    public class HangBus
    {
        public static IEnumerable<MobileShopConnection.HangSP> DanhSach()
        {
            var db = new MobileShopConnectionDB();
            return db.Query<MobileShopConnection.HangSP>("select * from HangSP where BiXoa != 1");
        }
        public static Page<HangSP> PageDanhSach(int PageNumber, int ItemPerPage)
        {
            var db = new MobileShopConnectionDB();
            return db.Page<HangSP>(PageNumber, ItemPerPage, "select * from HangSP where BiXoa != 1");
        }

        public static Page<MobileShopConnection.HangSP> PageDanhSachDaXoa(int PageNumber, int ItemPerPage)
        {
            var db = new MobileShopConnectionDB();
            return db.Page<HangSP>(PageNumber, ItemPerPage, "select * from HangSP where BiXoa = 1");
        }
        public static MobileShopConnection.HangSP ChiTiet(int id)
        {
            var db = new MobileShopConnectionDB();
            return db.SingleOrDefault<MobileShopConnection.HangSP>("select * from HangSP where MaHang=@0", id);
        }
        public static HangSP ChiTietViewModel(int? id)
        {

            using (var db = new MobileShopConnectionDB())
            {
                return db.Query<MobileShopConnection.HangSP>("select * from HangSP where MaHang = @0", id).FirstOrDefault();
            }
        }
        public static void Them(MobileShopConnection.HangSP HangSp)
        {
            var db = new MobileShopConnectionDB();
            db.Insert(HangSp);
        }
        public static void Xoa(int id)
        {
            var db = new MobileShopConnectionDB();
            var rs = Sql.Builder.Append("Exec XoaHangSP @0", id);
            db.Execute(rs);
        }
        public static void Sua(MobileShopConnection.HangSP HangSp)
        {
            var db = new MobileShopConnectionDB();
            db.Update(HangSp);
        }

        public static void KhoiPhuc(int id)
        {
            var db = new MobileShopConnectionDB();
            var rs = Sql.Builder.Append("Exec KhoiPhucHangSP @0", id);
            db.Execute(rs);
        }
    }
}