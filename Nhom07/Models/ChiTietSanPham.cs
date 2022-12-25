using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Nhom07.Models
{
    public class ChiTietSanPham
    {
        public int ID { get; set; }

        [DisplayName("Sản phẩm")]
        public int ID_SanPham { get; set; }

        // Reference navigation property cho khóa ngoại đến SanPham 
        [DisplayName("Sản phẩm")]
        public SanPham SanPham { get; set; }

        [DisplayName("Mặt kính")]
        public string MatKinh { get; set; }

        [DisplayName("Loại dây")]
        public string LoaiDay { get; set; }
    }
}
    