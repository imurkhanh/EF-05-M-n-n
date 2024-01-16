using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_05.Entity
{
    public class NguyenLieu
    {
        public int NguyenLieuId { get; set; }
        [Required]
        [MaxLength(20)]
        public string TenNguyenLieu { get; set; }
        public string GhiChu { get; set; }
    }
}
