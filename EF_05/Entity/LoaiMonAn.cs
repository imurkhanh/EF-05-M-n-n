using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_05.Entity
{
    public class LoaiMonAn
    {
        public int LoaiMonAnId { get; set; }
        [Required]
        [MaxLength(20)]
        public string TenLoai { get; set; }
        public string MoTa { get; set; }
    }
}
