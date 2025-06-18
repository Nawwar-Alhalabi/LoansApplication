using System.ComponentModel.DataAnnotations;

public class Loan
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    [Range(100_000, 10_000_000)]
    public int Amount { get; set; }
    [Range(12,36)]
    public int PeriodInMonths { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<Payment> Payments { get; set; } = new();

}