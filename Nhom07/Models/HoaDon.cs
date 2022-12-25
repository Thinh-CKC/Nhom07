using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nhom07.Models
{
    public class HoaDon
    {
        public int ID { get; set; }

        [DisplayName("Khách hàng")]
        public int ID_TaiKhoan { get; set; }

        // Reference navigation property cho khóa ngoại đến TaiKhoan 
        [DisplayName("Khách hàng")]
        public TaiKhoan TaiKhoan { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime NgayTao { get; set; }

        [DisplayName("Tổng tiền")]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public int TongTien { get; set; }

        // Collection navigation property cho khóa ngoại từ ChiTietHoaDon
        public List<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
