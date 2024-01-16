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
    public class MonAnService : IMonAnService
    {
        private readonly AppDbContext dbContext;

        public MonAnService()
        {
            dbContext = new AppDbContext();
        }
        public void ThemMonAn()
        {
            Console.WriteLine("Nhập loại món ăn ID: ");
            int loaiMonAnId = int.Parse(Console.ReadLine());
            var loaiMonAn = dbContext.LoaiMonAn.Find(loaiMonAnId);
            if(loaiMonAn == null)
            {
                Console.WriteLine("Không tồn tại loại món ăn");
            }    
            else
            {
                Console.WriteLine("Tên món: ");
                string tenMon=Console.ReadLine();
                Console.WriteLine("Giá bán: ");
                double giaBan = double.Parse(Console.ReadLine());
                Console.WriteLine("Giới thiệu: ");
                string gioiThieu = Console.ReadLine();
                Console.WriteLine("Cách làm: ");
                string cachLam = Console.ReadLine();

                MonAn monAn = new MonAn 
                {
                    LoaiMonAn=loaiMonAn,
                    TenMon=tenMon,
                    GiaBan=giaBan,
                    GioiThieu=gioiThieu,
                    CachLam=cachLam,
                };
                dbContext.Add(monAn);
                dbContext.SaveChanges();
                Console.WriteLine("Thêm món ăn thành công");
            }
        }

        public void TimKiemMonAnTheoTen()
        {
            Console.WriteLine("Nhập tên món ăn: ");
            string tenMonAn = Console.ReadLine();
            Console.WriteLine("Nhập tên nguyên liệu: ");
            string tenNguyenLieu = Console.ReadLine();
            var monAnList = dbContext.MonAn
                            .Join(dbContext.CongThuc, ma => ma.MonAnId, ct => ct.MonAnId, (ma, ct) => new { MonAn = ma, CongThuc = ct })
                            .Join(dbContext.NguyenLieu, ct => ct.CongThuc.NguyenLieuId, nl => nl.NguyenLieuId, (ct, nl) => new { CongThuc = ct, NguyenLieu = nl })
                            .Where(x => x.CongThuc.MonAn.TenMon.ToLower().Contains(tenMonAn.ToLower()) && x.NguyenLieu.TenNguyenLieu.ToLower().Contains(tenNguyenLieu.ToLower()))
                            .Select(x => x.CongThuc.MonAn.TenMon)
                            .ToList();

            if (monAnList.Count > 0)
            {
                Console.WriteLine($"Danh sách món ăn chứa tên món {tenMonAn} và nguyên liệu {tenNguyenLieu}");
                foreach (var monAn in monAnList)
                {
                    Console.WriteLine(monAn);
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy món ăn phù hợp");
            }
        }
    }
}
