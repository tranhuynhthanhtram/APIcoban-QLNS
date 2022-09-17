using System;
using System.Collections.Generic;

#nullable disable

namespace QLNS.DAL.Models
{
    public partial class Sach
    {
        public int Masach { get; set; }
        public string Tensach { get; set; }
        public int Matg { get; set; }
        public int Maloaisach { get; set; }
        public int? Giamua { get; set; }
        public int Manhaxuatban { get; set; }
        public DateTime? Namxuatban { get; set; }

        public virtual Loaisach MaloaisachNavigation { get; set; }
        public virtual Nhaxuatban ManhaxuatbanNavigation { get; set; }
        public virtual Tacgia MatgNavigation { get; set; }
    }
}
