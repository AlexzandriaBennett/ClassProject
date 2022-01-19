#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficialLab3.Data;
using OfficialLab3.DTO;
using OfficialLab3.Models;

namespace OfficialLab3.Controllers
{
    public class CoursesController : Controller
    {
        private readonly OfficialLab3Context _context;

        public CoursesController(OfficialLab3Context context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var officialLab3Context = _context.Course.Include(c => c.Teacher);
            return View(await officialLab3Context.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "StaffId", "StaffId");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,TeacherId")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "StaffId", "StaffId", course.TeacherId);
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "StaffId", "StaffId", course.TeacherId);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,TeacherId")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
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
            ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "StaffId", "StaffId", course.TeacherId);
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Course.FindAsync(id);
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.Id == id);
        }











        // GET: Courses/Enroll/
        public async Task<IActionResult> Enroll(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            //ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "StaffId", "StaffId", course.TeacherId);
            //ViewData["Name"] = new SelectList(_context.Set<Student>(), "Name");
            return View(course);
        }

        //// POST: Courses/Enroll/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Enroll(int id, [Bind("Id,Name,TeacherId")] Course course)
        //{
        //    if (id != course.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(course);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CourseExists(course.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "StaffId", "StaffId", course.TeacherId);
        //    return View(course);
        //}


        // get api/books
        //public IQueryable<StudentDto> GetStudents()
        //{
        //    var students = from s in _context.Student
        //                select new StudentDto()
        //                {
        //                    Name = s.Name,
        //                };

        //    return students;
        }

        //[ResponseType(typeof(StudentDetailDto))]
        //public async Task<IActionResult> GetBook(int id)
        //{
        //    var student = await _context.Student.Include(s => s.Name).Select(s =>
        //        new StudentDetailDto()
        //        {
        //            Name = s.Name,
        //            Id = s.Id,
                    
        //        }).SingleOrDefaultAsync(s => s.Id == id);
        //    if (student == null)
        //    {
        //        return (IActionResult)NotFound();
        //    }

        //    return (IActionResult)View(student);
        //}






        //[ResponseType(typeof(StudentDto))]
        //public async Task<IActionResult> PostStudent(Student student)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Student.Add(student);
        //    await _context.SaveChangesAsync();

        //    // New code:
        //    // Load author name
        //    _context.Entry(student).Reference(s => s.Name).Load();

        //    var dto = new BookDto()
        //    {
        //        Id = book.Id,
        //        Title = book.Title,
        //        AuthorName = book.Author.Name
        //    };

        //    return CreatedAtRoute("DefaultApi", new { id = book.Id }, dto);
        //}
    }






}
