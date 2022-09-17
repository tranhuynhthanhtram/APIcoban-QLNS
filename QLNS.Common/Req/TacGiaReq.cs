using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS.Common.Req
{
    public class TacGiaReq
    {
        public int Matg { get; set; }
        public string Tentg { get; set; }
        public DateTime? Namsinh { get; set; }
        public DateTime? Nammat { get; set; }
        public string Quequan { get; set; }
    }
}
