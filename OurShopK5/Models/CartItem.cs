using OurShopK5.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurShopK5.Models
{
    public class CartItem
    {
        public HangHoa HangMua { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien => SoLuong * HangMua.DonGia;
    }
}
