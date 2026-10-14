
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTest.Models;

public class SchoolsController : Controller
{
    private readonly AppDbContext _context;

    public SchoolsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: SCHOOLS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.School.ToListAsync());
    }

    // GET: SCHOOLS/Details/5
    public async Task<IActionResult> Details(int? schoolid)
    {
        if (schoolid == null)
        {
            return NotFound();
        }

        var school = await _context.School
            .FirstOrDefaultAsync(m => m.SchoolId == schoolid);
        if (school == null)
        {
            return NotFound();
        }

        return View(school);
    }

    // GET: SCHOOLS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: SCHOOLS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("SchoolId,SchoolName,city,Students")] School school)
    {
        if (ModelState.IsValid)
        {
            _context.Add(school);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(school);
    }

    // GET: SCHOOLS/Edit/5
    public async Task<IActionResult> Edit(int? schoolid)
    {
        if (schoolid == null)
        {
            return NotFound();
        }

        var school = await _context.School.FindAsync(schoolid);
        if (school == null)
        {
            return NotFound();
        }
        return View(school);
    }

    // POST: SCHOOLS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? schoolid, [Bind("SchoolId,SchoolName,city,Students")] School school)
    {
        if (schoolid != school.SchoolId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(school);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolExists(school.SchoolId))
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
        return View(school);
    }

    // GET: SCHOOLS/Delete/5
    public async Task<IActionResult> Delete(int? schoolid)
    {
        if (schoolid == null)
        {
            return NotFound();
        }

        var school = await _context.School
            .FirstOrDefaultAsync(m => m.SchoolId == schoolid);
        if (school == null)
        {
            return NotFound();
        }

        return View(school);
    }

    // POST: SCHOOLS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? schoolid)
    {
        var school = await _context.School.FindAsync(schoolid);
        if (school != null)
        {
            _context.School.Remove(school);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SchoolExists(int? schoolid)
    {
        return _context.School.Any(e => e.SchoolId == schoolid);
    }
}
