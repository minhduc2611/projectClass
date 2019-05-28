using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OurShopK5.DataModels
{
    [Table("CTDonHang")]
    public class ChiTietDonHang
    {
        public int Id { get; set; }
        public int MaDh { get; set; }
        public int MaHh { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien => SoLuong * DonGia;
        [ForeignKey("MaDh")]
        public DonHang DonHang { get; set; }
        [ForeignKey("MaHh")]
        public HangHoa HangHoa { get; set; }
    }
}
