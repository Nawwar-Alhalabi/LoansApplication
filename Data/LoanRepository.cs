using Microsoft.EntityFrameworkCore;

public class LoanRepository : ILoanRepository
{
    private readonly AppDbContext _context;

    public LoanRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Loan> AddLoanAsync(Loan loan)
    {
        _context.Loans.Add(loan);
        await _context.SaveChangesAsync();
        return loan;
    }

    public Customer CheckIfCustomerExist(string name)
    {
       var customer = _context.Customers
            .FirstOrDefault(c => c.Name.ToLower() == name.ToLower());

        if (customer == null)
        {
            customer = new Customer { Name = name };
            _context.Customers.Add(customer);
            _context.SaveChanges(); // Save so it gets an Id
        }
        return customer;
    } 
}