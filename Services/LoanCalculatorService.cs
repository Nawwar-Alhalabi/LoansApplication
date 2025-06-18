public class LoanCalculatorService : ILoanCalculatorService
{
    public IEnumerable<Payment> CalculateSchedule(int amount, int months)
    {
        var totalAmount = amount * 1.2m;
        var monthly = totalAmount / months;

        DateTime dateOfPayment = DateTime.Now;

        for (int i = 1; i <= months; i++)
        {
            yield return new Payment
            {
                DateOfPayment = dateOfPayment.AddMonths(i),
                MonthlyAmount = decimal.Round(monthly, 2)
            };
        }
    }
}