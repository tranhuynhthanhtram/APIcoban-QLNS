using System;
using System.Collections.Generic;

#nullable disable

namespace QLNS.DAL.Models
{
    public partial class Hoadon
    {
        public int Mahoadon { get; set; }
        public string Tenkhachhang { get; set; }
        public DateTime? Ngaylap { get; set; }
        public decimal? Tongtien { get; set; }
    }
}
