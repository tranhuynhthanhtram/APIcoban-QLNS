using System;
using System.Collections.Generic;

#nullable disable

namespace QLNS.DAL.Models
{
    public partial class Chitiethoadon
    {
        public int Mahoadon { get; set; }
        public int? Masach { get; set; }
        public int? Soluong { get; set; }
        public double? Giatien { get; set; }
        public double? Thanhtien { get; set; }

        public virtual Hoadon MahoadonNavigation { get; set; }
        public virtual Sach MasachNavigation { get; set; }
    }
}
