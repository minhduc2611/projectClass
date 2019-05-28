using Microsoft.AspNetCore.Mvc;
using OurShopK5.DataModels;

namespace OurShopK5.Components
{
    public class LoaiMenu : ViewComponent
    {
        private readonly MyDbContext ctx;
        public LoaiMenu(MyDbContext db)
        {
            ctx = db;
        }

        public IViewComponentResult Invoke()
        {
            return View(ctx.Loais);
        }
    }
}
