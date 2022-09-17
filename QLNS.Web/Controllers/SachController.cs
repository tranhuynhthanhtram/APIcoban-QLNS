//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using QLNS.BLL;
//using QLNS.Common.Req;
//using QLNS.Common.Rsp;
//using QLNS.DAL;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLNS.BLL;
using QLNS.Common.Req;
using QLNS.Common.Rsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLNS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SachController : ControllerBase
    {
        private SachSvc sachSvc;
        public SachController()
        {
            sachSvc = new SachSvc();
        }

        [HttpPost("get-by-id")]
        public IActionResult LaySachBangMa([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = sachSvc.Read(simpleReq.Id);
            return Ok(res);
        }

        [HttpPost("get-all")]
        public IActionResult LayTatCaSach()
        {
            var res = new SingleRsp();
            res.Data = sachSvc.All;
            return Ok(res);
        }
        [HttpPost("delete-book")]
        public IActionResult XoaSach([FromBody] int id)
        {
            var res = new SingleRsp();
            SachRep sachRep = new SachRep();
            res = sachRep.DeleteSach(id);
            return Ok(res);
        }
        [HttpPost("create-book")]
        public IActionResult CreateSach([FromBody] SachReq sachReq)
        {
            var res = new SingleRsp();
            res = sachSvc.CreateSach(sachReq);
            return Ok(res);
        }

        [HttpPost("update-book")]
        public IActionResult UpdateSach([FromBody] SachReq sachReq)
        {
            var res = new SingleRsp();
            res = sachSvc.UpdateSach(sachReq);
            return Ok(res);
        }

        [HttpPost("search-book")]
        public IActionResult SearchSach([FromBody] SearchSachReq searchSachReq)
        {
            var res = new SingleRsp();
            res = sachSvc.SearchSach(searchSachReq);
            return Ok(res);
        }
        [HttpPost("search-book-name")]
        public IActionResult SearchSachForName([FromBody] string tukhoa)
        {
            var res = new SingleRsp();
            SachRep sachRep = new SachRep();
            var saches = sachRep.SearchSach(tukhoa);
            res.Data = saches;
            return Ok(res);
        }


    }


}
