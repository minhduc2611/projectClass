using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OurShopK5.Models
{
    public class HangHoaView
    {
        [Key]        
        public int MaHh { get; set; }        
        public string TenHh { get; set; }        
        public string TenKhongDau { get; set; }        
        public string Hinh { get; set; }                
        public double DonGia { get; set; }        
        public byte GiamGia { get; set; }       
        public string Loai { get; set; }
        public bool DangGiamGia => GiamGia > 0;
        public double GiaBan => DonGia * (100 - GiamGia) / 100;
    }
}
