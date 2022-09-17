using QLNS.Common.DAL;
using QLNS.Common.Rsp;
using QLNS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.DAL
{
    public class TacGiaRep : GenericRep<QLNSContext, Tacgia>
    {
        public List<Tacgia> ListTacGia()
        {
            var res = All.ToList();
            return res;
        }
        //Thêm Sách
        public SingleRsp CreateTacGia(Models.Tacgia tacgia)
        {
            var res = new SingleRsp();
            using (var context = new QLNSContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var s = context.Tacgia.Add(tacgia);
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

        public SingleRsp UpdateTacGia(Tacgia tacgia)
        {
            var res = new SingleRsp();
            using (var context = new QLNSContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Tacgia.Update(tacgia);
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
        public SingleRsp DeleteTacGia(int id)
        {
            var res = new SingleRsp();
            using (var context = new QLNSContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Tacgia.SingleOrDefault(x => x.Matg == id);
                        if (p != null)
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
        public List<Tacgia> SearchTacGia(string tuKhoa)
        {
            return All.Where(x => x.Tentg.Contains(tuKhoa)).ToList();
        }
    }
}
  
