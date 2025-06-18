public interface ILoanRepository
{
    Task<Loan> AddLoanAsync(Loan loan);
}