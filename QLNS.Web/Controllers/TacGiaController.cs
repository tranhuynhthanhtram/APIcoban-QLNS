using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNS.BLL;
using QLNS.Common.Req;
using QLNS.Common.Rsp;

namespace QLNS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacGiaController : ControllerBase
    {
        private TacGiaSvc tacGiaSvc;
        public TacGiaController()
        {
            tacGiaSvc = new TacGiaSvc();
           
        }
        [HttpPost("get-by-id")]
        public IActionResult LaySachBangMa([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = tacGiaSvc.Read(simpleReq.Id);
            return Ok(res);
        }
    }
}
