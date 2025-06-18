using Microsoft.EntityFrameworkCore;

public class LoanFacade
{
    private readonly ILoanRepository _repo;
    private readonly ILoanCalculatorService _calc;

    public LoanFacade(ILoanRepository repo, ILoanCalculatorService calc)
    {
        _repo = repo;
        _calc = calc;
    }
    public async Task<Loan> CreateLoanAsync(string customerName, int amount, int months)
    {
        var schedule = _calc.CalculateSchedule(amount, months).ToList();

        var loan = new Loan
        {
            Customer = new Customer { Name = customerName },
            Amount = amount,
            PeriodInMonths = months,
            Payments = schedule
        };
        return await _repo.AddLoanAsync(loan);
    }

}