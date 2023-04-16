namespace WellsFargo.Services.Types;

public record Transaction(int SecurityId, int PortfolioId, int Nominal, OMS OMS, string TransactionType);
public record Security(int SecurityId, string ISIN, string Ticker, string CUSIP);
public record Portfolio(int PortfolioId, string PortfolioCode);