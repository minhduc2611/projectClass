using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OurShopK5.DataModels
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        [Display(Name ="Mã khách hàng")]
        [MaxLength(20, ErrorMessage ="Tối đa 20 kí tự")]
        public string MaKh { get; set; }
        [Display(Name ="Họ tên Khách hàng")]
        [MaxLength(150)]
        [Required(ErrorMessage ="*")]
        public string HoTen { get; set; }
        [Display(Name ="Giới tính")]
        public GioiTinh GioiTinh { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string MatKhau { get; set; }
        public bool ConHieuLuc { get; set; }
    }
    public enum GioiTinh
    {
        [Description("Nam")]
        Nam = 0,
        [Description("Nữ")]
        Nu = 1
    }
}
