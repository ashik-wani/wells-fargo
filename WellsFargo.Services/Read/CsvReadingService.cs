

namespace WellsFargo.Services.Read;

public class CsvReadingService : ICsvReadingService
{
    public async Task<T[]> ReadAsync<T>(string filePath, bool hasHeader = true, string fieldDelimiter = ",")
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = hasHeader,
            Delimiter= fieldDelimiter
        };

        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, config);
        var records = csv.GetRecordsAsync<T>();
        return await  records.ToArrayAsync();
    }
}

public static class AsyncEnumerableExtensions
{
    public static async Task<T[]> ToArrayAsync<T>(this IAsyncEnumerable<T> items,
        CancellationToken cancellationToken = default)
    {
        var results = new List<T>();
        await foreach (var item in items.WithCancellation(cancellationToken)
                                        .ConfigureAwait(false))
            results.Add(item);
        return results.ToArray();
    }
}