namespace WellsFargo.Services.Export;

public interface ICsvWriteService
{
    Task WriteAsync<T>(string workingFolder, string fileName, IEnumerable<T> list, bool hasHeader = true, string delimeter = ",");
}