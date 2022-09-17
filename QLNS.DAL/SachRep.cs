using QLNS.Common.DAL;
using QLNS.Common.Req;
using QLNS.Common.Rsp;
using QLNS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.DAL
{
    public class SachRep : GenericRep<QLNSContext,Sach>
    {
        #region -- Overrides --
        //Lấy ra Sách theo id truyền vào
        public override Sach Read(int id)
        {
            var res = All.FirstOrDefault(s => s.Masach == id);
            return res;
        }
        // Xóa Sách theo id truyền vào
        public int Remove(int id)
        {
            var m = base.All.First(i=>i.Masach == id);
            m = base.Delete(m);
            return m.Masach;
        }
        #endregion

        #region -- Method --
        public List<Sach> ListSach()
        {
            var res = All.ToList();
            return res;
        }
        //Thêm Sách
        public SingleRsp CreateSach(Models.Sach sach)
        {
            var res = new SingleRsp();
            using (var context = new QLNSContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var s = context.Saches.Add(sach);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        public SingleRsp UpdateSach(Sach sach)
        {
            var res = new SingleRsp();
            using (var context = new QLNSContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Saches.Update(sach);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
#pragma warning disable CS8604 // Possible null reference argument.
                        res.SetError(ex.StackTrace);
#pragma warning restore CS8604 // Possible null reference argument.
                    }
                }
            }
            return res;
        }
        public SingleRsp DeleteSach(int id)
        {
            var res = new SingleRsp();
            using (var context = new QLNSContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Saches.SingleOrDefault(x => x.Masach == id);
                        if(p != null)
                        {
                            context.Remove(p);
                            context.SaveChanges();
                            tran.Commit();
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
#pragma warning disable CS8604 // Possible null reference argument.
                        res.SetError(ex.StackTrace);
#pragma warning restore CS8604 // Possible null reference argument.
                    }
                }
            }
            return res;
        }
        public List<Sach> SearchSach(string tuKhoa)
        {
            return All.Where(x=>x.Tensach.Contains(tuKhoa)).ToList();
        }
        #endregion
    }
}
