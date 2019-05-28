using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OurShopK5.DataModels
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        [Display(Name ="Mã hàng hóa")]
        public int MaHh { get; set; }
        [Display(Name = "Tên hàng hóa")]
        [Required(ErrorMessage = "*")]
        [MaxLength(50, ErrorMessage = "Tối đa 50 kí tự")]
        public string TenHh { get; set; }
        [MaxLength(50)]
        public string TenKhongDau { get; set; }
        [Display(Name = "Hình")]
        [MaxLength(150, ErrorMessage = "Tối đa 150 kí tự")]
        public string Hinh { get; set; }
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
        [Display(Name = "Đơn giá")]
        public double DonGia { get; set; }
        [Display(Name = "Giảm giá")]
        [Range(0, 100, ErrorMessage ="Giảm giá từ 0 - 100%")]
        public byte GiamGia { get; set; }
        [Display(Name = "Loại")]
        public int MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }
    }

    [Table("QuaTang")]
    public class QuaTang
    {
        public int QuaTangId { get; set; }
        [Display(Name = "Tên quà tặng")]
        public string TenQua { get; set; }
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
        public string Code { get; set; }
        [Display(Name = "Hạn dùng")]
        public DateTime HanDung { get; set; }
    }

    [Table("NhanQua")]
    public class NhanQua
    {
        public int Id { get; set; }
        [Display(Name ="Quà tặng")]
        public int MaQT { get; set; }
        [Display(Name = "Hàng hóa")]
        public int MaHh { get; set; }
        [Display(Name = "Khách hàng")]
        public string MaKh { get; set; }
        [Display(Name = "Ngày nhận")]
        public DateTime? NgayNhan { get; set; }
        [ForeignKey("MaQT")]
        public QuaTang QuaTang { get; set; }
        [ForeignKey("MaHh")]
        public HangHoa HangHoa { get; set; }
    }
}
