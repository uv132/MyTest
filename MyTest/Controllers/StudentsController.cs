
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTest.Models;

public class StudentsController : Controller
{
    private readonly AppDbContext _context;

    public StudentsController(AppDbContext context)
    {
        _context = context;
    }


    // GET: STUDENTSS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Student.ToListAsync());
    }

    // GET: STUDENTSS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var students = await _context.Student
            .FirstOrDefaultAsync(m => m.Id == id);
        if (students == null)
        {
            return NotFound();
        }

        return View(students);
    }

    // GET: STUDENTSS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: STUDENTSS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,GradeLevel,SchoolId,School")] Students students)
    {
        if (ModelState.IsValid)
        {
            _context.Add(students);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(students);
    }

    // GET: STUDENTSS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var students = await _context.Student.FindAsync(id);
        if (students == null)
        {
            return NotFound();
        }
        return View(students);
    }

    // POST: STUDENTSS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,FirstName,LastName,GradeLevel,SchoolId,School")] Students students)
    {
        if (id != students.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(students);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsExists(students.Id))
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
        return View(students);
    }

    // GET: STUDENTSS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var students = await _context.Student
            .FirstOrDefaultAsync(m => m.Id == id);
        if (students == null)
        {
            return NotFound();
        }

        return View(students);
    }

    // POST: STUDENTSS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var students = await _context.Student.FindAsync(id);
        if (students != null)
        {
            _context.Student.Remove(students);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool StudentsExists(int? id)
    {
        return _context.Student.Any(e => e.Id == id);
    }
}
