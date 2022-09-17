using QLNS.Common.BLL;
using QLNS.Common.Req;
using QLNS.Common.Rsp;
using QLNS.DAL;

namespace QLNS.BLL
{
    public class SachSvc : GenericSvc<SachRep, Sach>
    {
        private SachRep sachRep;
        public SachSvc()
        {
            SachRep sachRep = new SachRep();
        }

        #region -- Overrides --
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }

        public override SingleRsp Update(Sach m)
        {
            var res = new SingleRsp();
            var m1 = m.Masach > 0 ? sachRep.Read(m.Masach) : sachRep.Read(m.Masach);

            if (m1 == null)
            {
                res.SetError("EZ103", "No data");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }
            return res;
        }
        #endregion

        public SingleRsp ListSach()//phương thức chưa có, nên không có kế thừa và phải tự viết
        {
            var res = new SingleRsp();
            var m = sachRep.ListSach();
            res.Data = m;
            return res;
        }
        public SingleRsp CreateSach(SachReq sachReq)
        {
            var res = new SingleRsp();
            SachRep sachRep = new SachRep();
            Sach sach = new Sach();
            sach.Masach = sachReq.Masach;
            sach.Tensach = sachReq.Tensach;
            sach.Giamua = sachReq.Giamua;
            sach.Maloaisach = sachReq.Maloaisach;
            sach.Manhaxuatban = sachReq.Manhaxuatban;
            sach.Namxuatban = sachReq.Namxuatban;
            sach.Matg = sachReq.Matg;
            res = sachRep.CreateSach(sach);
            return res;
        }

        public SingleRsp UpdateSach(SachReq sachReq)
        {
            var res = new SingleRsp();
            SachRep sachRep = new SachRep();
            Sach sach = new Sach();
            sach.Masach = sachReq.Masach;
            sach.Tensach = sachReq.Tensach;
            sach.Giamua = sachReq.Giamua;
            sach.Maloaisach = sachReq.Maloaisach;
            sach.Manhaxuatban = sachReq.Manhaxuatban;
            sach.Namxuatban = sachReq.Namxuatban;
            sach.Matg = sachReq.Matg;
            res = sachRep.UpdateSach(sach);
            return res;
        }
        
        public SingleRsp SearchSach(SearchSachReq s)
        {
            var res = new SingleRsp();
            //Lấy DSSP theo từ khóa
            var sachs = sachRep.SearchSach(s.Tukhoa);
            //Xử lý phần trang
            int soLuongSach, soTrang, soBatDau;
            soBatDau = s.Sodong * (s.Sotrang - 1);
            soLuongSach = sachs.Count;
            soTrang = (soLuongSach % s.Sodong) == 0 ? soLuongSach / s.Sodong : 1 + (soLuongSach / s.Sodong);
            //trả về dữ liệu trên từng trang
            var p = new
            {
                Data = sachs.Skip(soBatDau).Take(s.Sodong).ToList(),
                Page = s.Sotrang,
                Size = s.Sodong

            };
            res.Data = p;
            return res;
        }
       
    }
}
