using QLNS.Common.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNS.DAL.Models;

namespace QLNS.DAL
{
    public class LoaiSachRep : GenericRep<QLNSContext,Loaisach>
    {
        public LoaiSachRep()
        {

        }
        public override Loaisach Read(int id)
        {
            var res = All.FirstOrDefault(ls => ls.Maloaisach == id);
            return res;
        }

        public List<Loaisach> ListLoaiSach()
        {
            var res = All.ToList();
            return res;
        }
    }
}
