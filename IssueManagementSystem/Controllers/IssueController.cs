using IssueManagementSystem.Data;
using IssueManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IssueManagementSystem.Controllers
{
    public class IssueController : Controller
    {
        private readonly AppDbContext _context;
        public IssueController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string priority)
        {
            var issues = from i in _context.Issues
                         select i;

            if (!string.IsNullOrEmpty(priority))
            {
                issues = issues.Where(i => i.Priority == priority);
            }

            return View(await issues.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var issue = await _context.Issues
                .FirstOrDefaultAsync(m => m.Id == id);

            if (issue == null)
                return NotFound();

            return View(issue);
        }

        // =========================
        // 3. CREATE (GET)
        // =========================
        public IActionResult Create()
        {
            return View();
        }

        // =========================
        // 4. CREATE (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Issue issue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(issue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(issue);
        }

        // =========================
        // 5. EDIT (GET)
        // =========================
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var issue = await _context.Issues.FindAsync(id);

            if (issue == null)
                return NotFound();

            return View(issue);
        }

        // =========================
        // 6. EDIT (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Issue issue)
        {
            if (id != issue.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                issue.UpdatedDate = DateTime.Now;

                _context.Update(issue);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(issue);
        }

        // =========================
        // 7. DELETE (GET)
        // =========================
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var issue = await _context.Issues
                .FirstOrDefaultAsync(m => m.Id == id);

            if (issue == null)
                return NotFound();

            return View(issue);
        }

        // =========================
        // 8. DELETE (POST)
        // =========================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var issue = await _context.Issues.FindAsync(id);
            _context.Issues.Remove(issue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
