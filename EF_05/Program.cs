using EF_05.IService;
using EF_05.Service;

void Main()
{
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    Console.InputEncoding = System.Text.Encoding.UTF8;
    ICongThucService congThucService = new CongThucService();
    IMonAnService monAnService = new MonAnService();
    ILoaiMonAnService loaiMonAnService = new LoaiMonAnService();

    Console.WriteLine("---------------------QUẢN LÝ MÓN ĂN (EF-05)---------------------");
    Console.WriteLine("1. Thêm món ăn");
    Console.WriteLine("2. Thêm công thức món ăn và cập nhập cách làm");
    Console.WriteLine("3. Xóa loại món ăn");
    Console.WriteLine("4. Tìm kiếm món ăn theo tên và nguyên liệu chế biến món");
    Console.WriteLine("5. Thoát chương trình");

    string choice;
    do
    {
        Console.WriteLine();
        Console.Write("Nhập lựa chọn (1-5): ");
        choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                monAnService.ThemMonAn();
                break;
            case "2":
                congThucService.ThemCongThuc();
                Console.WriteLine("Cập nhập cách làm:");
                Console.WriteLine("Tên món ăn: ");
                string tenMonAn = Console.ReadLine();
                congThucService.UpdateCachLam(tenMonAn);
                break;
            case "3":
                loaiMonAnService.XoaLoaiMonAn();
                break;
            case "4":
                monAnService.TimKiemMonAnTheoTen();
                break;
            case "5":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Lựa chọn không hợp lệ.Vui lòng nhập lại");
                break;
        }

    } while (choice != "5");
}
Main();