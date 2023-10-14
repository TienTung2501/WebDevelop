using Microsoft.AspNetCore.Mvc;
using webtemplate.Data;
using webtemplate.Models;

namespace webtemplate.ViewComponents
{
    public class MajorViewComponent: ViewComponent
    {
        SchoolContext db;
        List <Major> majors;
        public MajorViewComponent(SchoolContext db)
        {
            this.db = db;
            this.majors = db.Majors.ToList();
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderMajor", majors);
        }
    }
}
