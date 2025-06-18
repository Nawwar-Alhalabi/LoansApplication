public interface ILoanCalculatorService
{
    IEnumerable<Payment> CalculateSchedule(int amount, int months);
}