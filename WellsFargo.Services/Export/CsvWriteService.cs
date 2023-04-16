namespace WellsFargo.Services.Export;

public class CsvWriteService : ICsvWriteService
{
    public async Task WriteAsync<T>(string workingFolder, string fileName, IEnumerable<T> list, bool hasHeader = true, string delimeter = ",")
    {
        var fullPath = Path.Combine(workingFolder, fileName.ToLower());

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = hasHeader,
            Delimiter = delimeter
        };


        using (var writer = new StreamWriter(fullPath))
        using (var csv = new CsvWriter(writer, config))
        {
            await csv.WriteRecordsAsync(list);
        }
    }
}