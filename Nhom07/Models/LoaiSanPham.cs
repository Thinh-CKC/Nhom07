using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nhom07.Models
{
    public class LoaiSanPham
    {
        public int ID { get; set; }

        [DisplayName("Loại sản phẩm")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string LoaiSP { get; set; }

        // Collection navigation property cho khóa ngoại từ SanPham
        public List<SanPham> SanPhams { get; set; }
    }
}
