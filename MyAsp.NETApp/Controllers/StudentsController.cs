//using Microsoft.AspNetCore.Localization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using MyAsp.NETApp.Data;
//using MyAsp.NETApp.Models;
//using X.PagedList;

//namespace MyAsp.NETApp.Controllers
//{
//    public class StudentsController : Controller
//    {
//        private readonly ItSparkTaskDbContext _context;

//        public StudentsController(ItSparkTaskDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Students
//        public IActionResult Index(string SearchText,int? page)
//        {
//            ViewData["CurrentFilter"] = SearchText;
//            var students = from s in _context.Students
//                           select s;

//            if (!string.IsNullOrEmpty(SearchText))
//            {
//                students = students.Where(s => s.Name.Contains(SearchText));
//            }

//            return View(students.ToPagedList(page ?? 1, 5));
//        }




//        // GET: Students/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null || _context.Students == null)
//            {
//                return NotFound();
//            }

//            var student = await _context.Students
//                .FirstOrDefaultAsync(m => m.StudentId == id);
//            if (student == null)
//            {
//                return NotFound();
//            }

//            return View(student);
//        }




//        // GET: Students/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Students/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Name,Gender,City,DateOfBirth,IsEnrolled,StudentId")] Student student)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(student);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(student);
//        }

//        // GET: Students/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.Students == null)
//            {
//                return NotFound();
//            }

//            var student = await _context.Students.FindAsync(id);
//            if (student == null)
//            {
//                return NotFound();
//            }
//            return View(student);
//        }

//        // POST: Students/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Name,Gender,City,DateOfBirth,IsEnrolled,StudentId")] Student student)
//        {
//            if (id != student.StudentId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(student);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!StudentExists(student.StudentId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(student);
//        }

//        // GET: Students/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.Students == null)
//            {
//                return NotFound();
//            }

//            var student = await _context.Students
//                .FirstOrDefaultAsync(m => m.StudentId == id);
//            if (student == null)
//            {
//                return NotFound();
//            }

//            return View(student);
//        }

//        // POST: Students/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            if (_context.Students == null)
//            {
//                return Problem("Entity set 'ItSparkTaskDbContext.Students'  is null.");
//            }
//            var student = await _context.Students.FindAsync(id);
//            if (student != null)
//            {
//                _context.Students.Remove(student);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool StudentExists(int id)
//        {
//          return (_context.Students?.Any(e => e.StudentId == id)).GetValueOrDefault();
//        }

//        public IActionResult SetLanguage(string culture, string returnUrl)
//        {
//            Response.Cookies.Append(
//                CookieRequestCultureProvider.DefaultCookieName,
//                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
//                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

//            return LocalRedirect(returnUrl);
//        }
//    }
//}
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAsp.NETApp.Data;
using MyAsp.NETApp.Models;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace MyAsp.NETApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ItSparkTaskDbContext _context;

        public StudentsController(ItSparkTaskDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public IActionResult Index(string SearchText, int? page)
        {
            ViewData["CurrentFilter"] = SearchText;
            var students = from s in _context.Students
                           select s;

            if (!string.IsNullOrEmpty(SearchText))
            {
                students = students.Where(s => s.Name.Contains(SearchText));
            }

            return View(students.ToPagedList(page ?? 1, 5));
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Gender,City,DateOfBirth,IsEnrolled,StudentId")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Gender,City,DateOfBirth,IsEnrolled,StudentId")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'ItSparkTaskDbContext.Students' is null.");
            }
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return (_context.Students?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }

        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return LocalRedirect(returnUrl);
        }
    }
}
