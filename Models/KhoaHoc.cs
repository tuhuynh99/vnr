using System;
using System.Collections.Generic;

namespace fourth.Models
{
    public partial class KhoaHoc
    {
        public KhoaHoc()
        {
            MonHocs = new HashSet<MonHoc>();
        }

        public int Id { get; set; }
        public string? TenKhoaHoc { get; set; }

        public virtual ICollection<MonHoc> MonHocs { get; set; }
    }
}
