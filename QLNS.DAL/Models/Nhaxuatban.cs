using System;
using System.Collections.Generic;

#nullable disable

namespace QLNS.DAL.Models
{
    public partial class Nhaxuatban
    {
        public Nhaxuatban()
        {
            Saches = new HashSet<Sach>();
        }
        public int Manhaxuatban { get; set; }
        public string Tennhaxuatban { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
