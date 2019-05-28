using Microsoft.AspNetCore.Mvc;
using OurShopK5.DataModels;
using OurShopK5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace OurShopK5.Controllers
{
    public class CartController : Controller
    {
        private readonly MyDbContext ctx;
        public CartController(MyDbContext db)
        {
            ctx = db;
        }
        public IActionResult Index()
        {
            return View(Cart);
        }

        public List<CartItem> Cart
        {
            get
            {
                List<CartItem> gioHang = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (gioHang == null) {
                    gioHang = new List<CartItem>();
                }
                return gioHang;
            }
        }

        public IActionResult AddToCart(int id)
        {
            //kiếm trong session đã có hàng hóa có mã id?
            List<CartItem> gioHang = Cart;

            //xử lý
            CartItem item = gioHang.SingleOrDefault(p => p.HangMua.MaHh == id);
            if (item != null)//đã có
            {
                item.SoLuong++;
            }
            else
            {
                //dựa vào id vào CSDL đọc lấy hàng hóa ra
                HangHoa hh = ctx.HangHoas.SingleOrDefault(p => p.MaHh == id);
                item = new CartItem
                {
                    HangMua = hh,
                    SoLuong = 1
                };

                gioHang.Add(item);
            }
            //lưu session
            HttpContext.Session.Set("GioHang", gioHang);

            //chuyển trang giỏ hàng
            return RedirectToAction("Index");

            ////trả về Json
            //return Json(new
            //{
            //    TongSoLuong = gioHang.Sum(p => p.SoLuong),
            //    TongTien = gioHang.Sum(p => p.ThanhTien)
            //});
        }

        [HttpPost("Cart/Checkout")]
        public IActionResult Checkout(KhachHangView model)
        {
            using (var transaction = ctx.Database.BeginTransaction())
            {
                try
                {
                    //chưa đăng nhập --> tạo mới khách hàng
                    KhachHang kh = new KhachHang
                    {
                        MaKh = $"KH{DateTime.Now.Ticks}",
                        HoTen = model.NguoiNhan,
                        Email = model.Email,
                        DiaChi = model.DiaChiGiaoHang
                    };
                    ctx.Add(kh);
                    ctx.SaveChanges();

                    //tạo đơn hàng
                    DonHang hd = new DonHang
                    {
                        MaKh = kh.MaKh,
                        DiaChiGiaoHang = model.DiaChiGiaoHang,
                        NguoiNhan = model.NguoiNhan,
                        NgayDatHang = DateTime.Now,
                        TongTien = Cart.Sum(p => p.ThanhTien),
                        TrangThaiDonHang = TrangThaiDonHang.MoiDangHang
                    };
                    ctx.Add(hd);
                    ctx.SaveChanges();

                    //tạo chi tiết đơn hàng
                    ChiTietDonHang cthd = null;
                    foreach(var item in Cart)
                    {
                        cthd = new ChiTietDonHang
                        {
                            MaDh = hd.Id,
                            MaHh = item.HangMua.MaHh,
                            SoLuong = item.SoLuong,
                            DonGia = item.HangMua.DonGia
                        };
                        ctx.Add(cthd);
                    }
                    ctx.SaveChanges();
                    transaction.Commit();
                    //xóa session
                    HttpContext.Session.Remove("GioHang");

                    //gửi mail thông tin đơn hàng cho khách hàng
                    string noiDung = $"Chào {model.NguoiNhan},<br>Bạn đặt hàng thành công đơn hàng <b>{hd.Id}</b>, tổng tiền thanh toán là: {hd.TongTien}.";
                    GoogleMailer.Send(model.Email, "Xac nhan Dat hang", noiDung);
                }
                catch(SmtpException mailEx)
                {

                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                }
            }
            return RedirectToAction("Index", "HangHoa");
        }
    }
}