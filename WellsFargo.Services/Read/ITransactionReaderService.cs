namespace WellsFargo.Services.Read;

public interface ITransactionReaderService
{
    Task<GenericList[]> ReadAsync(string workingFolder, string transactionFile);
}