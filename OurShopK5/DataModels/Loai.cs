using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OurShopK5.DataModels
{
    [Table("Loai")]
    public class Loai
    {
        [Key]
        [Display(Name ="Mã loại")]
        public int MaLoai { get; set; }
        [Display(Name = "Tên loại")]
        [MaxLength(50, ErrorMessage ="Tối đa 50 kí tự")]
        [Required(ErrorMessage ="*")]
        public string TenLoai { get; set; }
        [Display(Name = "Mô tả")]
        [MaxLength(50)]
        public string TenKhongDau { get; set; }
        public string MoTa { get; set; }
        [Display(Name = "Hình")]
        [MaxLength(150, ErrorMessage = "Tối đa 150 kí tự")]
        public string Hinh { get; set; }

        public int MaLoaiCha { get; set; }
    }
}
