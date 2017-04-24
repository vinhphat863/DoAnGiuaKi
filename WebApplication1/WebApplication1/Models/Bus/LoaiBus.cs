using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileShopConnection;
using PetaPoco;

namespace WebApplication1.Models.Bus
{
    public class LoaiBus
    {
        public static IEnumerable<MobileShopConnection.LoaiSP> DanhSach()
        {
            var db = new MobileShopConnectionDB();
            return db.Query<MobileShopConnection.LoaiSP>("select * from LoaiSP where BiXoa<>1");
        }
        public static Page<LoaiSP> PageDanhSach(int PageNumber, int ItemPerPage)
        {
            var db = new MobileShopConnectionDB();
            return db.Page<LoaiSP>(PageNumber, ItemPerPage, "select * from LoaiSP where BiXoa != 1");
        }
        public static MobileShopConnection.LoaiSP ChiTiet(int id)
        {
            var db = new MobileShopConnectionDB();
            return db.SingleOrDefault<MobileShopConnection.LoaiSP>("select * from LoaiSP where MaLoai=@0", id);
        }

        public static LoaiSP ChiTietViewModel(int? id)
        {

            using (var db = new MobileShopConnectionDB())
            {
                return db.Query<MobileShopConnection.LoaiSP>("select * from LoaiSP where MaLoai = @0", id).FirstOrDefault();
            }
        }

        public static Page<LoaiSP> PageDanhSachDaXoa(int PageNumber, int ItemPerPage)
        {
            var db = new MobileShopConnectionDB();
            return db.Page<LoaiSP>(PageNumber, ItemPerPage, "select * from LoaiSP where BiXoa = 1");
        }
        public static void Them(MobileShopConnection.LoaiSP LoaiSP)
        {
            var db = new MobileShopConnectionDB();
            db.Insert(LoaiSP);
        }
        public static void Xoa(int id)
        {
            var db = new MobileShopConnectionDB();
            var rs = Sql.Builder.Append("Exec XoaLoaiSP @0", id);
            db.Execute(rs);
        }
        public static void Sua(MobileShopConnection.LoaiSP LoaiSP)
        {
            var db = new MobileShopConnectionDB();
            db.Update(LoaiSP);
        }

        public static void KhoiPhuc(int id)
        {
            var db = new MobileShopConnectionDB();
            var rs = Sql.Builder.Append("Exec KhoiPhucLoaiSP @0", id);
            db.Execute(rs);
        }
    }
}