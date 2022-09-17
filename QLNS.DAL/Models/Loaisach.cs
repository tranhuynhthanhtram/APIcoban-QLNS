using System;
using System.Collections.Generic;

#nullable disable

namespace QLNS.DAL.Models
{
    public partial class Loaisach
    {
        public Loaisach()
        {
            Saches = new HashSet<Sach>();
        }

        public int Maloaisach { get; set; }
        public string Tenloaisach { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
