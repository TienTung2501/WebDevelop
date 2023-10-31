using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using webtemplate.Data;
using webtemplate.Models;

namespace webtemplate.Controllers
{
    public class LearnerController : Controller
    {
        private SchoolContext db;
        public LearnerController(SchoolContext context)
        {
            db=context;
        }
        public IActionResult Index()
        {
            int sizes = 5; // số phần tử của 1 trang
            var learners = db.Learners.Include(m => m.Major).ToList();
            ViewBag.PageSize = sizes;// truyền page size sang  sang view truyền vào thẻ a để thực hiện sự kiện load.
            ViewBag.pageCount = (int)Math.Ceiling((double)learners.Count / sizes);// tổng số trang       
            learners =learners.Take(sizes).ToList();
            return View(learners);
        }

        public IActionResult GetPage(int page, int pageSize)
        {
            // lý do không cập nhật được currentpage ở đây vì nó trả kêt quả ra parialview
            var totalRecords = db.Learners.Include(m => m.Major).Count();
            var pageCount = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (page < 1)
            {
                page = 1;
            }
            else if (page > pageCount)
            {
                page = pageCount;
            }
            var learners = db.Learners.Include(m => m.Major)
                .Skip((page - 1) * pageSize)// bỏ qua những thằng từ page trước lấy đủ 5 thằng
                .Take(pageSize)
                .ToList();
            
            return PartialView("LearnerTable", learners);
        }
        public IActionResult LearnerByMajorID(int mid)
        {
        
                var learners = db.Learners.Where(l => l.MajorID == mid).Include(m => m.Major).ToList();// include để join và lấy name major theo thằng major
                return PartialView("LearnerTable", learners);
        }

        public IActionResult Create() {
            var majors = new List<SelectListItem>();
                foreach(var item in db.Majors)
                {
                    majors.Add(new SelectListItem { Text = item.MajorName, Value = item.MajorID.ToString() });
                }
            ViewBag.MajorID = majors;
            return View();
         }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstMidName,LastName,MajorID,EnrollmentDate")] Learner learner)
        {
            if(ModelState.IsValid)
            {
                db.Learners.Add(learner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");
            return View();
        }
        //thêm 2 action edit 
        public IActionResult Edit(int id)
        {
            if (id == null || db.Learners == null)
            {
                return NotFound();
            }
            var learner = db.Learners.Find(id);
            if (learner == null)
            {
                return NotFound();
            }
            ViewBag.MajorId = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID); 
            return View(learner);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("LearnerID, FirstMidName, LastName, MajorID, EnrollmentDate")] Learner learner)
        {
            if (id != learner.LearnerID)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    db.Update(learner);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!LearnerExists(learner.LearnerID))
                        return NotFound();
                    else throw;
                        
                }
                return RedirectToAction(nameof(Index));
                
            }
            ViewBag.MajorsId = new SelectList(db.Majors, "MajorID", "MajorName",learner.MajorID);

            return View(learner);
        }
        private bool LearnerExists(int id)
        {
            return (db.Learners?.Any(e=>e.LearnerID==id)).GetValueOrDefault();
        }
        //thêm 2 action edit 
        public IActionResult Delete(int id)
        {
            if (id == null || db.Learners == null)
            {
                return NotFound();
            }
            var learner = db.Learners.Include(l => l.Major)
            .Include(e => e.Enrollments)
            .FirstOrDefault(m => m.LearnerID == id);
            if (learner == null)
            {
                return NotFound();
            }
            if (learner.Enrollments.Count() > 0)
            {
                return Content("This learner has some enrollments, can't delete!"); 
            }
            return View(learner);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (db.Learners == null)
            {
                return Problem("Entity set 'Learners' is null.");
            }
            var learner = db.Learners.Find(id);
            if (learner != null)
            {
                db.Learners.Remove(learner);
            }
            db.SaveChanges(); 
            return RedirectToAction(nameof (Index));
        }

    }
}
