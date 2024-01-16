using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_05.Entity
{
    public class MonAn
    {
        public int MonAnId { get; set; }
        [Required]
        [MaxLength(20)]
        public string TenMon { get; set; }
        public double GiaBan { get; set; }
        public string GioiThieu { get; set; }
        [Required]
        public string CachLam { get; set; }
        public int LoaiMonAnId { get; set; }
        public LoaiMonAn LoaiMonAn { get; set; }
    }
}
