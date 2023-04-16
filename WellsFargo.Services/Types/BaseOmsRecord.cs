namespace WellsFargo.Services.Types;

public abstract class BaseOmsRecord
{
    public string PortfolioCode { get; set; } = string.Empty;
    public decimal Nominal { get; set; }
    public string TransactionType { get; set; } = string.Empty;
}
