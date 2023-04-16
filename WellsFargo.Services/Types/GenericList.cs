namespace WellsFargo.Services.Types;

public class GenericList : BaseOmsRecord
{
    public OMS OMS { get; set; }
    public string ISIN { get; set; }
    public string CUSIP { get; set; }
    public string Ticker { get; set; }
}
