using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Diagnostics;

class ChuongTrinhGame
{
    static string nguoichoi = string.Empty;

    public static void Main()
    {
        // Thiết lập bộ mã hóa đầu ra để hiển thị tiếng Việt có dấu
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.Unicode;

        // Gọi hàm hiển thị tên trò chơi.
        NameGame();
        // Tạo thông báo yêu cầu người dùng nhấn phím bất kỳ để tiếp tục.
        string message = "Nhấn phím bất kỳ để tiếp tục...";
        // In thông báo ở giữa màn hình
        Print((Console.BufferWidth - message.Length) / 2,
                 Console.BufferHeight / 2 + 7,
              message,
                  ConsoleColor.DarkRed);
        Console.ReadKey(true);
        // Vòng lặp vô hạn, xóa màn hình và hiển thị menu mỗi lần lặp.
        while (true)
        {
            Console.Clear();
            ShowMenu();
        }
    }

    public static void NameGame()
    {
        // Mảng chứa các dòng đồ họa ASCII để hiển thị tên trò chơi
        string[] Name = new string[]
        {
                @" _______   ___                            ___                                      _______                          ",
                @"/ $$$$$ \  $$|                            $$|                             ___     /$$$$$$$\                            ",
                @"$$     $ | $$|                            $$|                            /$$$\    $$      $|                            ",
                @"$$     $$| $$|                            $$|                            \$$$/    $$ $$$$ $|                            ",
                @"$$ $$$ $$| $$|___    ______     ______    $$|        ______     ______    __      $$ _____/    ______      ______   ",
                @"$$ _____/  $$ $$$\  / $$$$$|   /$$$ $$\   $$|       / $$$$ \   / $$$$$|   $$|     $$ | $$$\   / $$$$$|   /$$$$$$/    ",
                @"$$ |       $$ __$| $$$   $$|_   $$__ $|   $$|       $$    $$| $$$   $$|_  $$|     $$ |   $$\ $$$   $$|_  $$  --    ",
                @"$$ |       $$ | $|  $$    $$|$| $$|  $|   $$|____   $$    $$| $$    $$$|$ $$|     $$ |    $$\ $$    $$$| $$$|____   ",
                @"$$ |       $$ | $|   $$$$$$$ /  $$/  $/   $$$$$$$$$  $$$$$ /   $$$$$$$ /  $$|     $$ |      $\ $$$$$$$/   \$$$$$$\   ",
        };
        // In tên trò chơi ở giữa màn hình với màu xanh lá
        Print((Console.BufferWidth - Name[0].Length) / 2,
              Math.Max(0, Console.BufferHeight / 2 - 6),
              Name,
              ConsoleColor.DarkGreen);
    }
    // Hàm in mảng chuỗi tại vị trí (x, y)
    public static void Print(int x, int y, string text, ConsoleColor color)
    {
        // Kiểm tra điều kiện nếu tọa độ nằm ngoài giới hạn màn hình console.
        if (x < 0 || y < 0 || y >= Console.BufferHeight) return;
        // Đặt con trỏ console đến vị trí chỉ định
        Console.SetCursorPosition(Math.Max(0, x), y);
        Console.ForegroundColor = color; // Thiết lập màu chữ
        Console.Write(text.Length > Console.BufferWidth ? text.Substring(0, Console.BufferWidth) : text); // Cắt chuỗi nếu dài hơn chiều rộng màn hình
        Console.ResetColor();
    }

    // Hàm in mảng chuỗi tại vị trí (x, y)
    public static void Print(int x, int y, string[] text, ConsoleColor color)
    {
        for (int i = 0; i < text.Length; i++) // Duyệt qua từng dòng trong mảng chuỗi
        {
            // Nếu tọa độ dòng vượt ngoài chiều cao màn hình thì dừng lại
            if (y + i >= Console.BufferHeight) break;
            // Cắt dòng nếu vượt quá chiều rộng màn hình console.
            string line = text[i].Length > Console.BufferWidth
                          ? text[i].Substring(0, Console.BufferWidth) : text[i];
            // Đặt con trỏ console đến vị trí dòng hiện tại
            Console.SetCursorPosition(Math.Max(0, x), y + i);
            Console.ForegroundColor = color; // Thiết lập màu chữ
            Console.Write(line);
        }
        Console.ResetColor();
    }

    static void ShowMenu() // Hàm in menu game
    {
        // Xóa tất cả nội dung hiển thị trước đó trên màn hình console
        Console.Clear();
        // Tính toán vị trí y bắt đầu và x để căn giữa
        int yStart = (Console.BufferHeight - 3) / 2;
        int xStart = (Console.BufferWidth - 60) / 2;

        // In dòng trên cùng của menu với từng màu cho chức năng
        Console.SetCursorPosition(xStart, yStart); // Đặt vị trí con trỏ
        Console.ForegroundColor = ConsoleColor.Green; // Đặt màu xanh lá
        Console.Write("┏━━━━━━━━━━━━━━━━━┓   ");
        Console.ForegroundColor = ConsoleColor.Yellow; // Đặt màu vàng
        Console.Write("┏━━━━━━━━━━━━━━━━━┓   ");
        Console.ForegroundColor = ConsoleColor.Red; // Đặt màu đỏ
        Console.WriteLine("┏━━━━━━━━━━━━━━━━━┓   ");

        // In dòng giữa của menu với từng màu cho chức năng
        Console.SetCursorPosition(xStart, yStart + 1); // Di chuyển xuống 1 dòng
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("┃ 1. Bắt đầu chơi ┃   ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("┃  2. Hướng dẫn   ┃   ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("┃    3. Thoát     ┃");

        // In dòng dưới cùng của menu với từng màu cho chức năng
        Console.SetCursorPosition(xStart, yStart + 2); // Di chuyển xuống 2 dòng
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("┗━━━━━━━━━━━━━━━━━┛   ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("┗━━━━━━━━━━━━━━━━━┛   ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("┗━━━━━━━━━━━━━━━━━┛   ");
        Console.ResetColor();


        // In lời nhắc nhập lựa chọn bên dưới menu
        string nhapphim = "Mời bấm phím để lựa chọn: ";
        // Tính toán vị trí để căn giữa cho lời nhắc nhập lựa chọn
        int nhapphimX = (Console.BufferWidth - nhapphim.Length) / 2;
        Console.SetCursorPosition(nhapphimX, yStart + 4);
        Console.Write(nhapphim);

        // Xử lý nhập lựa chọn
        int choice;
        try
        {
            // Đọc lựa chọn từ người dùng và chuyển đổi thành số nguyên
            choice = int.Parse(Console.ReadLine());
        }
        catch (FormatException) // Xử lý lỗi nếu nhập không phải số nguyên hợp lệ
        {
            Console.WriteLine("Vui lòng nhập một số nguyên hợp lệ.");
            Console.WriteLine("Ấn phím bất kỳ để tiếp tục...");
            Console.ReadKey();
            return; // Quay lại menu
        }

        // Điều hướng đến chức năng tương ứng dựa vào lựa chọn
        switch (choice)
        {
            case 1:
                NhapThongTin(); // Gọi hàm NhapThongTin
                break;

            case 2:
                HuongDanChoi(); // Gọi hàm HuongDanChoi
                break;

            case 3:
                Environment.Exit(0); // Thoát khỏi menu
                break;

            default:
                // Thông báo khi lựa chọn không hợp lệ
                string[] baoloi = new string[]
                    {@"Phím bấm không hợp lệ",
                     @"Ấn phím bất kỳ để nhập lại"
                    };
                int baoloiY = yStart + 5; // Ngay dưới dòng "Mời bấm phím để lựa chọn:"
                foreach (var line in baoloi)
                {
                    int baoloiX = (Console.BufferWidth - line.Length) / 2; // Căn giữa dòng lỗi
                    Console.SetCursorPosition(baoloiX, baoloiY++);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(line);
                }
                Console.ResetColor(); Console.ReadKey();
                break;
        }
    }


    static void NhapThongTin() // Hàm nhập thông tin người chơi
    {
        // Xóa tất cả nội dung hiển thị trước đó trên màn hình console
        Console.Clear();

        while (true)
        {
            try
            {
                Console.Write("Nhập tên người chơi: ");
                nguoichoi = Console.ReadLine();
                // Kiểm tra xem tên có rỗng không
                if (string.IsNullOrWhiteSpace(nguoichoi))
                {
                    throw new Exception("Tên người chơi không thể rỗng");
                }
                // Kiểm tra xem tên có phải là số không
                if (nguoichoi.All(char.IsDigit))
                {
                    throw new Exception("Tên người chơi không thể là số");
                }
                break; // Nếu không có lỗi, thoát khỏi vòng lặp
            }
            // In thông báo lỗi
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        Console.WriteLine($"Chào mừng {nguoichoi} đến với game!");
        Console.WriteLine("Nhấn phím bất kỳ để bắt đầu game hoặc ESC để quay lại menu chính.");

        while (true)
        {
            var key = Console.ReadKey(true).Key;  // Đọc phím nhấn từ người dùng
            if (key == ConsoleKey.Escape) // Nếu nhấn ESC, quay lại menu chính
            {
                return; // Quay lại menu chính
            }
            else
            {
                XuLyChoi(); // Gọi hàm XuLyChoi để vào chơi game
                break; // Thoát khỏi vòng lặp
            }
        }
    }
    static void HuongDanChoi() // Hàm hiển thị hướng dẫn chơi
    {
        // Xóa màn hình console
        Console.Clear();
        // In hướng dẫn chơi
        Console.WriteLine("\t\tHƯỚNG DẪN");
        Console.WriteLine("Khi bạn bấm vào chơi thì máy sẽ ngẫu nhiên đưa ra 1 câu hỏi trong bộ câu hỏi có sẵn. ");
        Console.WriteLine("Sau đó bạn sẽ suy nghĩ và chọn đáp án đúng.");
        Console.WriteLine("Do đây là mô hình phân loại 7 nên sẽ quy ước: \r\n1. Chất lỏng\r\n2. Thực phẩm thừa\r\n3. Kim loại\r\n4. Nhựa tái chế\r\n5. Giấy\r\n6. Hộp sữa \r\n7. Rác thải còn lại. \r\n");
        Console.WriteLine("Trò chơi gồm 3 round, mỗi round sẽ có 5 câu hỏi theo mức độ khó tăng dần: trả lời đúng 1 câu sẽ được 1 điểm");
        Console.WriteLine("\nNhấn ESC để thoát hướng dẫn");

        // Đợi người dùng nhấn ESC để thoát hướng dẫn
        while (Console.ReadKey().Key != ConsoleKey.Escape) ;

    }
    static void XuLyChoi()
    {
        Console.Clear();
        Random rand = new Random(); // Khởi tạo đối tượng Random để trộn câu hỏi

        // Khởi tạo danh sách câu hỏi và đáp án bằng mảng hai chiều với 30 hàng và 5 
        string[,] cauhoi = new string[30, 5] {
 {"Những rác thải nào thuộc nhóm “Rác thải còn lại”?", "A. Túi nilon, hộp xốp, dụng cụ ăn uống gỗ", "B. Hộp sữa giấy, bìa carton", "C. Hộp nhựa, ống hút nhựa", "D. Hộp thực phẩm, đinh, ốc" },
{"Giấy báo, giấy vở, bìa carton thuộc loại rác nào?", "A. Rác thải còn lại", "B. Hộp sữa", "C. Giấy","D. Kim loại" },
{"“Mô hình 3” của UEH Go Green Station gồm:", "A. Chất lỏng, thực phẩm thừa, rác thải còn lại", "B. Thực phẩm thừa, rác tái chế, rác thải còn lại", "C. Chất lỏng, giấy, hộp sữa", "D. Thực phẩm thừa, rác tái chế, chất lỏng" },
{"Trung bình một người Việt Nam thải ra bao nhiêu tấn CO2 mỗi năm?","A. 2 tấn", "B. 3 tấn", "C. 2,5 tấn", "D. 2,3 tấn" },
{"Trước khi xả thải, UEHer, cá nhân ra vào UEH, cần phải làm gì?", "A. Bóc tách rác", "B. Thực hiện cùng lúc phương án A và C", "C. Phân loại rác", "D. Bỏ tất cả vào 1 túi" },
{ "UEHer hay khách vào UEH cần phải tuân thủ nguyên tắc phân loại rác theo mô hình:", "A. Mô hình 4 và 5", "B. Mô hình 5 và 6", "C. Mô hình 3 và 7", "D. Mô hình 5 và 7" },
{ "Hộp thực phẩm làm bằng kim loại sẽ thuộc nhóm nào trong Mô hình 7?", "A. Kim loại", "B. Chất lỏng", "C. Rác thải còn lại", "D. Rác tái chế" },
{ "Loại rác nào dưới đây không thuộc nhóm “Rác tái chế”?", "A. Giấy báo", "B. Chai nhựa", "C. Khẩu trang y tế", "D. Hộp sữa giấy" },
{ "Một chai lọ bị vỡ nên được xử lý như thế nào?", "A. Phân loại vào nhóm Thực phẩm thừa", "B. Bọc kỹ bằng giấy và bỏ vào nhóm Rác thải còn lại", "C. Bỏ trực tiếp vào nhóm Rác thải còn lại", "D. Đập nhỏ thành mảnh vụn trước khi bỏ vào thùng tái chế" },
{ "Những rác thải nào sau đây cần được phân vào nhóm Rác tái chế: ", "A. Chai, lọ nhựa, rác sân vườn", "B. Giấy báo, ly giấy, đinh, ốc", "C. Dụng cụ ăn uống gỗ, ống hút nhựa", "D. Khăn giấy, khẩu trang" },
{ "Khi bạn uống không hết ly matcha latte, phần thừa còn lại trong ly cần được phân loại vào nhóm: ", "A. Rác tái chế", "B. Rác thải còn lại", "C. Giấy", "D. Chất lỏng" },
{ "Loại giấy nào dưới đây được phân loại vào nhóm \"Giấy\" trong mô hình 7? ", "A. Khăn giấy đã qua sử dụng", "B. Giấy báo, sách cũ", "C. Vỏ hộp sữa giấy", "D. Giấy vệ sinh đã qua sử dụng" },
{ "Chất nào sau đây là chất thải khó phân hủy? ", "A. Giấy", "B. Vật chất nhôm", "C. Giấy nhôm", "D. Bông" },
{ "Chất thải động vật có thể chuyển đổi thành… ", "A. Khí tự nhiên", "B. Khí dầu lỏng (LPG)", "C. Khí sinh học", "D. Không có cái nào ở trên" },
{ "Chất thải rắn bao gồm tất cả các loại sau đây, ngoại trừ: ", "A. Báo và chai nước ngọt", "B. Thức ăn thừa và mảnh sân", "C. Ozone và carbon dioxide", "D. Thư rác và hộp sữa" },
{ "Loại chất thải nào phân hủy hoàn toàn khi chôn vào đất? ", "A. Chất thải thực vật", "B. Chất thải nhựa", "C. Chất thải kim loại", "D. Chất thải động vật" },
{ "Rác thải nào sau đây là rác hữu cơ? ", "A. Xương cá", "B. Túi nilon", "C. Pin đã qua sử dụng", "D. Hộp sữa giấy" },
{ "Rác thải nguy hại bao gồm loại nào sau đây? ", "A. Hộp sữa đã qua sử dụng", "B. Pin, ắc quy cũ", "C. Lốp xe cũ", "D. Giấy carton" },
{ "Kim loại phế liệu thuộc loại rác nào? ", "A. Rác thải nguy hại", "B. Rác tái chế", "C. Rác hữu cơ", "D. Rác sinh hoạt không tái chế" },
{ "Bạn đang uống cà phê mang đi và thấy một thùng rác phân loại. Ly cà phê của bạn thuộc loại nào? ", "A. Rác hữu cơ", "B. Rác tái chế (sau khi rửa sạch)", "C. Rác thải nguy hại", "D. Rác thải thông thường" },
{ "Một chiếc áo cũ nhưng vẫn sử dụng được nên làm gì? ","A. Vứt vào thùng rác tái chế", "B. Tặng hoặc tái sử dụng", "C. Vứt chung với rác sinh hoạt", "D. Bỏ vào thùng rác hữu cơ" },
{ "Bạn nên xử lý dầu ăn thừa như thế nào? ", "A. Đổ vào bồn rửa chén", "B. Đổ trực tiếp ra môi trường", "C. Lưu trữ trong chai và giao cho đơn vị xử lý dầu thải", "D. Bỏ vào thùng rác tái chế" },
{ "Pin cũ nếu không được xử lý đúng cách sẽ gây nguy hại gì?", "A. Gây cháy nổ", "B. Ô nhiễm đất và nước", "C. Phát tán kim loại nặng vào môi trường", "D. Tất cả các ý trên" },
{ "Bình xịt (như bình sơn, thuốc diệt côn trùng) thuộc loại rác nào? ", "A. Rác tái chế", "B. Rác thải nguy hại", "C. Rác hữu cơ", "D. Rác sinh hoạt thông thường" },
{ "Giấy thuộc phân loại rác nào trong “Mô hình 3” của UEH Go Green Station? ", "A. Giấy", "B. Rác tái chế", "C. Rác thải còn lại", "D. Nhựa tái chế" },
{ "Tốn bao nhiêu thời gian để phân hủy 1 chai nước làm từ nhựa PET ngoài tự nhiên ", "A. 100 - 500 năm để phân hủy hoàn toàn", "B. 450 - 1000 năm để phân hủy hoàn toàn", "C. 500 năm", "D. 100 năm" },
{ "Quy trình nào sau đây là quy trình tái chế nhựa? ", "A. Nghiền nhỏ, rửa sạch, nấu chảy, ép khuôn", "B. Đốt cháy, lọc khí, làm mát", "C. Phơi nắng, sấy khô, nghiền nát", "D. Rửa sạch, cắt nhỏ, chôn lấp, ủ phân" },
{ "Những vật dụng nào sau đây có thể dùng thủy tinh tái chế để chế tạo? ", "A. Chip máy tính", "B. Giấy", "C. Bê tông", "D. Sơn" },
{ "Nên chọn loại chai nhựa nào dưới đây để có thể sử dụng lại nhiều lần và giảm phát thải? ", "A. Chai nhựa nào cũng như nhau", "B. Chai nhựa PET", "C. Chọn loại chai nhựa rẻ nhất", "D. Chai nhựa HDPE" },
{ "Mô hình nào 3R được áp dụng cho dự án UEH Green Campus để phân loại và xử lý rác gồm các bước nào sau đây: ", "A. Rethink, refuse, reduce", "B. Reduce, reuse, recycle", "C. Rethink, reduce, responsibility", "D. Refuse, reduce, reuse" }
};//các câu hỏi trong bộ ngân hàng câu hỏi về chủ đề “Phân loại rác” 

        string[] dapAnDung = { "A", "C", "B", "D", "B", "C", "A", "C", "B", "B", "D", "B", "C", "C", "C", "A", "A", "B", "B", "B", "B", "C", "D", "B", "B", "B", "A", "C", "D", "B" }; ; // Đáp án đúng tương ứng với các câu hỏi

        int soCauHoi = cauhoi.GetLength(0); // Lưu số lượng câu hỏi vào biến (30 câu hỏi)
        int soVong = 3; // 3 vòng chơi
        int soCauHoiMoiVong = 5; // 5 câu hỏi mỗi vòng
        int tongDiem = 0; // Biến lưu tổng điểm của người chơi trong toàn bộ trò 

        // Vòng lặp chính cho từng vòng chơi, vòng lặp này chạy từ 1 đến chỉ số biến  soVong
        for (int vong = 1; vong <= soVong; vong++)
        {
            //Bắt đầu đếm thời gian  cho mỗi vòng
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            //Biến kiểm tra trạng thái của quyền trợ giúp 50/50 trong mỗi vòng
            bool daSuDung5050 = false;  //Khi nó có giá trị false, có nghĩa là người chơi chưa sử dụng quyền trợ giúp này

            //Thay đổi màu chữ sang màu đỏ và hiển thị tiêu đề vòng hiện tại.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n--- Vòng {vong} ---");

            int diem = 0; // Điểm của người chơi trong vòng hiện tại

            //Trộn danh sách chỉ số câu hỏi
            List<int> indexList = Enumerable.Range(0, soCauHoi).OrderBy(x => rand.Next()).ToList();
            for (int i = 0; i < soCauHoiMoiVong; i++)
            {
                if (stopWatch.Elapsed.TotalSeconds >= 30) // Nếu hết thời gian 30s, kết thúc vòng chơi
                {
                    break;
                }

                int index = indexList[i]; // Lấy chỉ số câu hỏi sau khi trộn

                // Hiển thị câu hỏi và các tùy chọn
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                // Hiển thị khung câu hỏi
                Console.Write($"╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n║Câu hỏi số {0}: {1}", i + 1, cauhoi[index, 0]); //cauhoi[index,0]: nội dung câu 
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                // Hiển thị đáp án với cauhoi[index,1] đến cauhoi[index, 4] là các lựa chọn trả lời
                Console.WriteLine(" {0}", cauhoi[index, 1]);
                Console.WriteLine(" {0}", cauhoi[index, 2]);
                Console.WriteLine(" {0}", cauhoi[index, 3]);
                Console.WriteLine(" {0}", cauhoi[index, 4]);
                Console.WriteLine($"╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");

                // Hỏi người chơi có muốn sử dụng quyền trợ giúp 50/50 không
                if (!daSuDung5050)
                {
                    string chon5050 = " "; //khởi tạo biến với khoảng trống
                    while (true)
                    {
                        // Hỏi người chơi xem có muốn sử dụng 50/50 không
                        try
                        {

                            Console.WriteLine("\nBạn có muốn sử dụng quyền trợ giúp 50/50 không? (Y/N)");
                            chon5050 = Console.ReadLine()?.ToUpper();
                            if (chon5050 == "Y" || chon5050 == "N")
                                break;
                            else
                                throw new Exception("Mời bạn nhập đúng Y hoặc N");
                        }
                        catch (Exception loi)
                        {
                            Console.WriteLine(loi.Message);
                        }
                    }


                    if (chon5050 == "Y") //Người chơi muốn sử dụng 50/50, chức năng loại bỏ 2 đáp án sai đã được sử dụng trong vòng này
                    {
                        daSuDung5050 = true; // Đánh dấu đã sử dụng 50/50

                        // Sử dụng quyền trợ giúp 50/50
                        //Tạo 1 list kiểu string có tên là options để tạo ra một danh sách mới có tên là options và gán cho nó các lựa chọn trả lời của câu hỏi ở chỉ số index của mảng cauhoi, danh sách này gồm 4 lựa chọn trả lời
                        List<string> options = new List<string> { cauhoi[index, 1], cauhoi[index, 2], cauhoi[index, 3], cauhoi[index, 4] };
                        //Khai báo biến correctAnswer kiểu chuỗi để lưu trữ đáp án đúng của câu hỏi, dapAnDung[index] là đáp án đúng của câu hỏi ở chỉ số index
                        string correctAnswer = cauhoi[index, dapAnDung[index] == "A" ? 1 : (dapAnDung[index] == "B" ? 2 : (dapAnDung[index] == "C" ? 3 : 4))]; 

                        //Gọi hàm UseFiftyFifty  để xóa 2 đáp án sai
                        UseFiftyFifty(options, correctAnswer);

                        // Hiển thị lại câu hỏi với 2 đáp án còn lại
                        Console.WriteLine("\nSau khi sử dụng quyền trợ giúp 50/50:");
                        DisplayOptions(options);

                    }
                }
                else
                {
                    Console.WriteLine("Bạn đã sử dụng chức năng 50/50 cho vòng này rồi!");
                }

                // Nhập câu trả lời của người chơi
                string traloi = ""; //Khởi tạo biến traloi kiểu string với khoảng trống
                while (true)
                {
                    try
                    {
                        Console.Write("\nNhập câu trả lời của bạn (A/B/C/D): ");
                        traloi = Console.ReadLine()?.ToUpper();

                        if (traloi == "A" || traloi == "B" || traloi == "C" || traloi == "D")
                            break;
                        else
                            throw new Exception("Vui lòng chỉ nhập A, B, C hoặc D.");
                    }
                    catch (Exception loi)
                    {
                        Console.WriteLine(loi.Message);
                    }
                }

                if (traloi == dapAnDung[index]) //Kiểm tra người chơi có chọn đúng đáp án không
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bạn đã chọn đáp án đúng.");
                    diem++; //Nếu người chơi trả lời đúng thì điểm tăng lên 1
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sai rồi. Đáp án đúng là: {0}.", dapAnDung[index]);
                }

                //Nếu người chơi hoàn thành đủ 5 câu hỏi trước 30s, kết thúc vòng chơi
                if (i == 5)
                {
                    break;
                }

            }

            stopWatch.Stop(); //Kết thúc đồng hồ vòng chơi
            Console.WriteLine("\nBạn đã hoàn thành vòng {0} với số điểm: {1}/{2}", vong, diem, soCauHoiMoiVong);
            tongDiem += diem; //Cộng điểm của vòng hiện tại vào tổng điểm

            // Hàm trợ giúp để hiển thị các lựa chọn
            static void DisplayOptions(List<string> options)
            {
                foreach (var option in options) //Vòng lặp duyệt qua từng phần tử trong danh sách options
                                                //var option: biến option sẽ nhận từng giá trị trong danh sách options
                                                //Mỗi phần tử (tức là một lựa chọn trả lời) sẽ được gán vào biến option  trong mỗi vòng lặp.
                {
                    if (!string.IsNullOrEmpty(option)) //Nếu lựa chọn trả lời là chuỗi và không null hoặc rỗng thì tiến hành in ra các lựa chọn
                    {

                        Console.WriteLine($" {option}");
                    }
                }
            }

            // Hàm trợ giúp để sử dụng quyền trợ giúp 50/50
            static void UseFiftyFifty(List<string> options, string correctAnswer) // // Xóa 2 câu trả lời sai (giữ lại câu trả lời đúng và 1 câu sai)

            {
                List<string> wrongAnswers = options.Where(x => x != correctAnswer).OrderBy(x => Guid.NewGuid()).Take(2).ToList(); //Lấy ngẫu nhiên 2 câu trả lời sai
                foreach (var wrongAnswer in wrongAnswers) //duyệt qua các đáp án sai trong danh sách wrongAnswers
                {
                    options.Remove(wrongAnswer); //tìm và xóa phần tử đầu tiên có giá trị bằng wrongAnswer trong danh sách options.
                }
            }
        }
        Console.ReadKey();
        KetThucGame(tongDiem); //gọi hàm KetThucGame
    }

    //Gán điểm và điểm cao nhất ban đầu bằng 0
    static int diemCaoNhat = 0;
    static void KetThucGame(int tongDiem)
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t╔══════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("\t║                         TRÒ CHƠI KẾT THÚC                        ║");
        Console.WriteLine("\t╠══════════════════════════════════════════════════════════════════╣");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\t║ Điểm của bạn là: {tongDiem,-48}║");

        if (tongDiem > diemCaoNhat) //Kiểm tra tổng điểm có lớn hơn điểm cao nhất hay không
        {
            diemCaoNhat = tongDiem; //Nếu có thì điểm cao nhất sẽ bằng với tổng điểm hiện tại
        }
        //Thông báo điểm rèn luyện nếu điểm vượt mốc 10
        if (tongDiem > 10)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\t║ Xin chúc mừng! Bạn đã nhận được 2 điểm rèn luyện.{"",-16}║");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\t║ Rất tiếc. Bạn không nhận được điểm rèn luyện.{"",-20}║");
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t╠══════════════════════════════════════════════════════════════════╣");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"\t║ ĐIỂM CAO NHẤT: {diemCaoNhat,-50}║");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t╚══════════════════════════════════════════════════════════════════╝");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\n\tNhấn Enter để quay lại bảng chọn, R để chơi lại, hoặc Tab để hiện Bảng xếp hạng.");
        Console.ResetColor();

        string filepath = "KetQuaChoi.txt"; //khai báo một biến chuỗi filepath và gán cho nó giá trị "KetQuaChoi.txt".
        using (StreamWriter sw = new StreamWriter(filepath, true)) //Ghi dữ liệu vào file văn bản 
                                                                   //Dòng mã này tạo một đối tượng StreamWriter với đường dẫn file đã chỉ định (trong biến filepath)
                                                                   //true là tham số thứ hai trong StreamWriter, có nghĩa là nếu file đã tồn tại, chương trình sẽ mở file và ghi dữ liệu vào cuối file.

        {
            sw.WriteLine($"Tên người chơi: {nguoichoi}"); //Lưu tên người chơi
            sw.WriteLine($"Điểm: {tongDiem}"); //Lưu tổng điểm
            sw.WriteLine($"Ngày chơi: {DateTime.Now}"); //Lưu thời gian chơi
            sw.WriteLine("======================================");
        }

        bool nenThoat = false; //biến nenThoat dùng để theo dõi trạng thái của thoát game trong trò chơi.
                               //Khi nó có giá trị false, có nghĩa là người chơi chưa muốn thoát

        while (!nenThoat) //Khi người chơi chưa thoát
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true); //ConsoleKeyInfo: chứa thông tin về phím mà người dùng nhấn
                                                            //Console.ReadKey(true): đọc phím nhưng không hiện phím đó trên màn hình console.
                                                            //Xử lý lựa chọn từ phím của người chơi
            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                    nenThoat = true;
                    break;
                case ConsoleKey.Tab:
                    Bangxephang(); // Hiển thị bảng xếp hạng
                    Console.Clear(); // Xóa màn hình sau khi thoát khỏi bảng xếp hạng
                    Console.WriteLine("\n\tNhấn Enter để quay lại bảng chọn hoặc R để chơi lại.");
                    break;
                default:
                    if (keyInfo.KeyChar == 'r' || keyInfo.KeyChar == 'R') // Chơi lại
                    {
                        XuLyChoi();
                        nenThoat = true;
                    }
                    break;
            }
        }

        //Bangxephang();
    }
    public static void Bangxephang()
    {
        string filepath = "KetQuaChoi.txt";    // Đường dẫn tới tệp chứa kết quả chơi

        // Kiểm tra nếu file không tồn tại
        if (!File.Exists(filepath))
        {
            Console.WriteLine("Không có dữ liệu bảng xếp hạng.");
            return;     // Kết thúc hàm nếu không tìm thấy tệp
        }

        // Tạo danh sách lưu trữ thông tin người chơi (Tên, Điểm, Ngày chơi)
        var lines = File.ReadAllLines(filepath);
        // Tạo danh sách lưu trữ thông tin người chơi (Tên, Điểm, Ngày chơi)
        var scores = new List<(string Name, int Score, DateTime Date)>();

        // Duyệt qua từng nhóm 4 dòng
        for (int i = 0; i < lines.Length; i += 4)
        {
            try
            {
                // Lấy tên người chơi từ dòng thứ i, loại bỏ phần tiền tố "Tên người chơi: "                
                string name = lines[i].Replace("Tên người chơi: ", "").Trim();
                // Lấy điểm số từ dòng thứ i + 1, loại bỏ phần tiền tố "Điểm: "
                int score = int.Parse(lines[i + 1].Replace("Điểm: ", "").Trim());
                // Lấy ngày chơi từ dòng thứ i + 2, loại bỏ phần tiền tố "Ngày chơi: "
                DateTime date = DateTime.Parse(lines[i + 2].Replace("Ngày chơi: ", "").Trim());
                // Thêm thông tin đã xử lý vào danh sách
                scores.Add((name, score, date));
            }
            catch
            {
                // Bỏ qua lỗi nếu dữ liệu không đúng định dạng
                continue;
            }
        }

        // Sắp xếp danh sách theo điểm giảm dần
        scores = scores.OrderByDescending(s => s.Score).ToList();

        // Hiển thị giao diện bảng xếp hạng
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("                                   BẢNG XẾP HẠNG                                    ");
        Console.WriteLine("  ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━  ");
        Console.WriteLine("   Tên người chơi             |    Điểm       |    Ngày chơi                       ");
        Console.WriteLine("  ────────────────────────────────────────────────────────────────────────────────  ");

        Console.ForegroundColor = ConsoleColor.White;

        int rank = 1;
        foreach (var score in scores.Take(10)) // Chỉ hiển thị top 10 trong danh sách điểm
        {
            Console.WriteLine($"   {rank++,-3} {score.Name,-25} {score.Score,-12} {score.Date:dd/MM/yyyy HH:mm}");
        }

        Console.WriteLine("\n  Nhấn phím bất kỳ để quay lại menu.");
        Console.ReadKey();
    }

}



