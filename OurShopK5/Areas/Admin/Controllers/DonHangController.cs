using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OurShopK5.DataModels;

namespace OurShopK5.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DonHangController : Controller
    {
        private readonly MyDbContext _context;

        public DonHangController(MyDbContext context)
        {
            _context = context;
        }

        [Route("Admin/DonHang")]
        // GET: Admin/DonHang
        public async Task<IActionResult> Index(DateTime TuNgay, DateTime DenNgay, string KhachHang="")
        {
            var data = _context.DonHangs.AsQueryable();

            if (TuNgay == DateTime.MinValue) {
                TuNgay = DateTime.Now.AddDays(-7);
                data = data.Where(p => p.NgayDatHang >= TuNgay);
            }
            if (DenNgay == DateTime.MinValue) {
                DenNgay = DateTime.Now;
                data = data.Where(p => p.NgayDatHang <= DenNgay);

            }
            if (!string.IsNullOrEmpty(KhachHang)) {
                data = data.Where(p => p.NguoiNhan.Contains(KhachHang));
            }
            data = data.OrderByDescending(p => p.NgayDatHang);
            ViewBag.TuNgay = TuNgay;
            ViewBag.DenNgay = DenNgay;
            ViewBag.KhachHang = KhachHang;
            //var myDbContext = _context.DonHangs.Include(d => d.KhachHang);
            //return View(await myDbContext.ToListAsync());
            return View(await data.ToListAsync());
        }

        // GET: Admin/DonHang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHangs
                .Include(d => d.KhachHang)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // GET: Admin/DonHang/Create
        public IActionResult Create()
        {
            ViewData["MaKh"] = new SelectList(_context.KhachHangs, "MaKh", "MaKh");
            return View();
        }

        // POST: Admin/DonHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NgayDatHang,TrangThaiDonHang,TongTien,MaKh,NguoiNhan,DiaChiGiaoHang")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKh"] = new SelectList(_context.KhachHangs, "MaKh", "MaKh", donHang.MaKh);
            return View(donHang);
        }

        // GET: Admin/DonHang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHangs.FindAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }
            ViewData["MaKh"] = new SelectList(_context.KhachHangs, "MaKh", "MaKh", donHang.MaKh);

            var ctdh = _context.ChiTietDonHangs.Where(p => p.MaDh == donHang.Id).Include(p => p.HangHoa);
            ViewBag.ChiTietHangHoa = ctdh;

            var StatusList = new List<SelectListItem>();

            foreach (TrangThaiDonHang tt in Enum.GetValues(typeof(TrangThaiDonHang))) {
                StatusList.Add(new SelectListItem
                {
                    Text = Enum.GetName(typeof(TrangThaiDonHang), tt),
                    Value = tt.GetHashCode().ToString()
                });
            }

            return View(donHang);
        }

        // POST: Admin/DonHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NgayDatHang,TrangThaiDonHang,TongTien,MaKh,NguoiNhan,DiaChiGiaoHang")] DonHang donHang)
        {
            if (id != donHang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonHangExists(donHang.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKh"] = new SelectList(_context.KhachHangs, "MaKh", "MaKh", donHang.MaKh);
            return View(donHang);
        }

        // GET: Admin/DonHang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHangs
                .Include(d => d.KhachHang)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // POST: Admin/DonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donHang = await _context.DonHangs.FindAsync(id);
            _context.DonHangs.Remove(donHang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonHangExists(int id)
        {
            return _context.DonHangs.Any(e => e.Id == id);
        }
    }
}
