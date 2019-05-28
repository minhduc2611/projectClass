using OurShopK5.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurShopK5.Models
{
    public class LoaiSelectModel
    {
        public List<Loai> Data { get; set; }
        public int? Select { get; set; }
    }
}
