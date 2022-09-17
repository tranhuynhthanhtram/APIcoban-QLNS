using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNS.BLL;
using QLNS.Common.Req;
using QLNS.Common.Rsp;

namespace QLNS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiSachController : ControllerBase
    {
        public LoaiSachSvc loaiSachSvc;
        public LoaiSachController()
        {
            loaiSachSvc = new LoaiSachSvc();    
        }
        [HttpPost("get-by-id")]
        public IActionResult LayLoaiSachBangMa([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = loaiSachSvc.Read(simpleReq.Id);
            return Ok(res);
        }

        [HttpPost("get-all")]
        public IActionResult LayTatCaLoaiSach()
        {
            var res = new SingleRsp();
            //res.Data = loaiSachSvc.ListLoaiSach();
            res.Data = loaiSachSvc.All;
            return Ok(res);
        }
    }
}
