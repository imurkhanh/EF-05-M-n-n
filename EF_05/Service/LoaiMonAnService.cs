using EF_05.Entity;
using EF_05.IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_05.Service
{
    public class LoaiMonAnService : ILoaiMonAnService
    {
        private readonly AppDbContext dbContext;

        public LoaiMonAnService()
        {
            dbContext = new AppDbContext();
        }
        public void XoaLoaiMonAn()
        {
            Console.WriteLine("Nhập loại món ăn ID cần xóa: ");
            int loaiMonAnId = int.Parse(Console.ReadLine());

            var loaiMonAnDelete = dbContext.MonAn
                              .Join(dbContext.CongThuc, ma => ma.MonAnId, ct => ct.MonAnId, (ma, ct) => new { MonAn = ma, CongThuc = ct })
                              .Join(dbContext.NguyenLieu, ct => ct.CongThuc.NguyenLieuId, nl => nl.NguyenLieuId, (ct, nl) => new { CongThuc = ct, NguyenLieu = nl })
                              .Join(dbContext.LoaiMonAn, ma => ma.CongThuc.MonAn.LoaiMonAnId, lma => lma.LoaiMonAnId, (ma, lma) => new { MonAn = ma, LoaiMonAn = lma })
                              .Select(x => x.LoaiMonAn.LoaiMonAnId)
                              .ToList();
            if(loaiMonAnDelete != null)
            {
                dbContext.Remove(loaiMonAnDelete);
                dbContext.SaveChanges();
                Console.WriteLine("Xóa loại món ăn thành công");
            }
            else
            {
                Console.WriteLine("Không tồn tại loại món ăn cần xóa");
            }    
        }
    }
}
