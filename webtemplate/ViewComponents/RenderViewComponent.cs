using Microsoft.AspNetCore.Mvc;
using webtemplate.Models;
namespace webtemplate.ViewComponents
{
    public class RenderViewComponent:ViewComponent
    {
        private List<MenuItem> Menu_items= new List<MenuItem>()
        {
            new MenuItem()
            {
                Id=1, Name ="Branches", Link="Branches/List"
            },new MenuItem()
            {
                Id=2, Name ="Students", Link="Students/List"
            },new MenuItem()
            {
                Id=3, Name ="Subjects", Link="Subjects/List"
            },new MenuItem()
            {
                Id=4, Name ="Courses", Link="Courses/List"
            
            }

        };
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderLeftMenu",Menu_items);//tìm đến thư mục con có tên cùng tên với viewcompoent đây là 1 khuôn mẫu đặt tên, và đặt tên file giống tên truyền vào
            //không đồng bộ:chia việc nạp dữ liệu không thuộc một tiến trình đó, nó sẽ thực hiện trên 1 tiến trình khác
            //đồng bộ: truyền thông dữ liệu tuần tự theo cách sử lý của cpu
        }
    }
}
