namespace WellsFargo.Services.Export;

public class ExportMapper : IExportMapper
{
    public IEnumerable<AAAList> MapAAA(GenericList[] list)
    {
        return from t in list
               where t.OMS == OMS.AAA
               select new AAAList
               {
                   ISIN = t.ISIN,
                   PortfolioCode = t.PortfolioCode,
                   Nominal = t.Nominal,
                   TransactionType = t.TransactionType
               };
    }

    public IEnumerable<BBBList> MapBBB(GenericList[] list)
    {
        return from t in list
               where t.OMS == OMS.BBB
               select new BBBList
               {
                   CUSIP = t.CUSIP,
                   PortfolioCode = t.PortfolioCode,
                   Nominal = t.Nominal,
                   TransactionType = t.TransactionType
               };
    }

    public IEnumerable<CCCList> MapCCC(GenericList[] list)
    {
        return from t in list
               where t.OMS == OMS.CCC
               && t.TransactionType == Constants.TRANSACTION_TYPE_BUY
               select new CCCList
               {
                   PortfolioCode = t.PortfolioCode,
                   Ticker = t.Ticker,
                   Nominal = t.Nominal,
                   TransactionType = t.TransactionType == Constants.TRANSACTION_TYPE_BUY ? "B" : "S" //this is only going to be buy
               };
    }
}
