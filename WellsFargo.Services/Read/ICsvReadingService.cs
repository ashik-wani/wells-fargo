namespace WellsFargo.Services.Read;

public interface ICsvReadingService
{
    Task<T[]> ReadAsync<T>(string filePath, bool hasHeader = true, string fieldDelimiter = ",");
}