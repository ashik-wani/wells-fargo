namespace WellsFargo.Services.Read;

public class TransactionReaderService : ITransactionReaderService
{
    private readonly ICsvReadingService csvReadingService;

    public TransactionReaderService(ICsvReadingService csvReadingService)
    {
        this.csvReadingService = csvReadingService;
    }

    public async Task<GenericList[]> ReadAsync(string workingFolder, string transactionFile)
    {
        var transactionFilePath = Path.Combine(workingFolder, transactionFile);
        var transactions = await csvReadingService.ReadAsync<Transaction>(transactionFilePath);

        var securityFilePath = Path.Combine(workingFolder, "securities.csv");
        var securities = await csvReadingService.ReadAsync<Security>(securityFilePath);

        var portfolioFilePath = Path.Combine(workingFolder, "portfolios.csv");
        var portfolios = await csvReadingService.ReadAsync<Portfolio>(portfolioFilePath);


        var list = from t in transactions
                   join p in portfolios on t.PortfolioId equals p.PortfolioId
                   join s in securities on t.SecurityId equals s.SecurityId
                   select new GenericList
                   {
                       CUSIP = s.CUSIP,
                       Ticker = s.Ticker,
                       ISIN = s.ISIN,
                       PortfolioCode = p.PortfolioCode,
                       Nominal = t.Nominal,
                       TransactionType = t.TransactionType,
                       OMS = t.OMS
                   };
        return list.ToArray();
    }
}
