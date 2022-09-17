using QLNS.Common.BLL;
using QLNS.Common.Req;
using QLNS.Common.Rsp;
using QLNS.DAL;
using QLNS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.BLL
{
    public class TacGiaSvc : GenericSvc<TacGiaRep, Tacgia>
    {
        private TacGiaRep tacGiaRep;
        public TacGiaSvc()
        {
            TacGiaRep tacGiaRep = new TacGiaRep();
        }

       
        public SingleRsp ListTacGia()//phương thức chưa có, nên không có kế thừa và phải tự viết
        {
            var res = new SingleRsp();
            var m = tacGiaRep.ListTacGia();
            res.Data = m;
            return res;
        }
    }
}