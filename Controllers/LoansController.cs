using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class LoansController : Controller
{
    private readonly LoanFacade _facade;
    private readonly AppDbContext _context;

    public LoansController(LoanFacade facade, AppDbContext context)
    {
        _facade = facade;
        _context = context;
    }

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(string customerName, int amount, int months)
    {
        if (amount < 100_000 || amount > 10_000_000)
            ModelState.AddModelError("amount", "المبلغ يجب أن يكون بين 100 ألف و10 مليون.");

        if (!new[] { 12, 24, 36 }.Contains(months))
            ModelState.AddModelError("months", "عدد الأشهر غير صالح.");

        if (!ModelState.IsValid) return View();

        var loan = await _facade.CreateLoanAsync(customerName, amount, months);
        return RedirectToAction("Details", new { id = loan.Id });
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var loan =  _context.Loans.Include(l => l.Customer).Include(l => l.Payments)
            .FirstOrDefault(l => l.Id == id);
        return loan == null ? NotFound() : View(loan);
    }

    [HttpPost]
    public async Task<IActionResult> Search(string customerName)
    {
        var result = await _context.Loans.Include(x => x.Customer).Include(x => x.Payments)
             .Where(x => x.Customer.Name == customerName).ToListAsync();
        if (result.Count == 0 || result is null)
        {
            ViewBag.Message = "لم يتم العثور على زبون بهذا الاسم.";
            return View();
        }
        return View(result);
    }
    public IActionResult Search()
    {
        return View();
    }
}