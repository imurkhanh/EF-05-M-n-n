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
    public class CongThucService:ICongThucService
    {
        private readonly AppDbContext dbContext;

        public CongThucService()
        {
            dbContext = new AppDbContext();
        }

        public void ThemCongThuc()
        {
            Console.WriteLine("Nhập nguyên liệu ID: ");
            int nguyenLieuId = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhập món ăn ID: ");
            int monAnId = int.Parse(Console.ReadLine());
            var nguyenLieu = dbContext.NguyenLieu.Find(nguyenLieuId);
            var monAn = dbContext.MonAn.Find(monAnId);
            if( monAn == null )
            {
                return;
            }
            if(nguyenLieu == null )
            {
                return;
            }
            Console.WriteLine("Số lượng: ");
            int soLuong = int.Parse(Console.ReadLine());
            Console.WriteLine("Đơn vị tính: ");
            string donViTinh = Console.ReadLine();
            var congThuc = new CongThuc
            {
                NguyenLieuId=nguyenLieuId,
                MonAnId=monAnId,
                SoLuong=soLuong,
                DonViTinh=donViTinh,
            };
            dbContext.Add(congThuc); 
            dbContext.SaveChanges();
            Console.WriteLine("Thêm công thức thành công");
        }

        public string UpdateCachLam(string tenMonAn)
        {
            var cachLam = dbContext.MonAn
                .Join(dbContext.CongThuc, ma => ma.MonAnId, ct => ct.MonAnId, (ma, ct) => new { MonAn = ma, CongThuc = ct })
                .Join(dbContext.NguyenLieu, ct => ct.CongThuc.NguyenLieuId, nl => nl.NguyenLieuId, (ct, nl) => new { CongThuc = ct, NguyenLieu = nl })
                .Where(x => x.CongThuc.MonAn.TenMon.ToLower() == tenMonAn.ToLower())
                .Select(x => new { x.NguyenLieu.TenNguyenLieu, x.CongThuc.CongThuc.SoLuong, x.CongThuc.CongThuc.DonViTinh }).ToList();
            if (cachLam.Count >= 0)
            {
                string result = "";
                foreach (var temp in cachLam)
                {
                    result += $"{temp.TenNguyenLieu} : {temp.SoLuong} {temp.DonViTinh} ";
                }
                return result;
            }
            else
            {
                return "Món ăn chưa có cách làm";
            }
        }
    }
}
