using System;
using System.Collections.Generic;

#nullable disable

namespace QLNS.DAL.Models
{
    public partial class Tacgia
    {
        public Tacgia()
        {
            Saches = new HashSet<Sach>();
        }

        public int Matg { get; set; }
        public string Tentg { get; set; }
        public DateTime? Namsinh { get; set; }
        public DateTime? Nammat { get; set; }
        public string Quequan { get; set; }

        public virtual ICollection<Sach> Saches { get; set; }
    }
}
