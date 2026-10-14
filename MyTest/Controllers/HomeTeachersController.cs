
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTest.Models;

public class HomeTeachersController : Controller
{
    private readonly AppDbContext _context;

    public HomeTeachersController(AppDbContext context)
    {
        _context = context;
    }

    // GET: HOMETEACHERS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.HomeTeacher.ToListAsync());
    }

    // GET: HOMETEACHERS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var hometeacher = await _context.HomeTeacher
            .FirstOrDefaultAsync(m => m.Id == id);
        if (hometeacher == null)
        {
            return NotFound();
        }

        return View(hometeacher);
    }

    // GET: HOMETEACHERS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: HOMETEACHERS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,TeacherName,Subject,teachergender,Students")] HomeTeacher hometeacher)
    {
        if (ModelState.IsValid)
        {
            _context.Add(hometeacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(hometeacher);
    }

    // GET: HOMETEACHERS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var hometeacher = await _context.HomeTeacher.FindAsync(id);
        if (hometeacher == null)
        {
            return NotFound();
        }
        return View(hometeacher);
    }

    // POST: HOMETEACHERS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,TeacherName,Subject,teachergender,Students")] HomeTeacher hometeacher)
    {
        if (id != hometeacher.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(hometeacher);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeTeacherExists(hometeacher.Id))
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
        return View(hometeacher);
    }

    // GET: HOMETEACHERS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var hometeacher = await _context.HomeTeacher
            .FirstOrDefaultAsync(m => m.Id == id);
        if (hometeacher == null)
        {
            return NotFound();
        }

        return View(hometeacher);
    }

    // POST: HOMETEACHERS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var hometeacher = await _context.HomeTeacher.FindAsync(id);
        if (hometeacher != null)
        {
            _context.HomeTeacher.Remove(hometeacher);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool HomeTeacherExists(int? id)
    {
        return _context.HomeTeacher.Any(e => e.Id == id);
    }
}
