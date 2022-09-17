using QLNS.Common.BLL;
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
    public class LoaiSachSvc : GenericSvc<LoaiSachRep,Loaisach>
    {
        private LoaiSachRep loaiSachRep;
        public LoaiSachSvc()
        {
            loaiSachRep = new LoaiSachRep();
        }
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data=_rep.Read(id);
            return res;
        }

        public SingleRsp ListLoaiSach()//phương thức chưa có, nên không có kế thừa và phải tự viết
        {
            var res = new SingleRsp();
            var m = loaiSachRep.ListLoaiSach();
            res.Data = m;// Data dữ liệu truyền vào đây là danh sách loại sản phẩm ở dòng trên 
            return res;
        }
    }
}
