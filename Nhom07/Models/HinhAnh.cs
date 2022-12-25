using System.ComponentModel;

namespace Nhom07.Models
{
    public class HinhAnh
    {
        public int ID { get; set; }

        [DisplayName("Sản phẩm")]
        public int ID_SanPham { get; set; }

        // Reference navigation property cho khóa ngoại đến SanPham 
        [DisplayName("Sản phẩm")]
        public SanPham SanPham { get; set; }

        [DisplayName("Ảnh")]
        public string Anh { get; set; }
    }
}
