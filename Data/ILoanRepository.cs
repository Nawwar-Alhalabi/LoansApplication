public interface ILoanRepository
{
    Task<Loan> AddLoanAsync(Loan loan);
    Customer CheckIfCustomerExist(string name);
}