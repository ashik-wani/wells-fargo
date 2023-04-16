

namespace WellsFargo.Services;
public class TransactionProcessor
{
    private readonly ITransactionReaderService transactionReaderService;
    private readonly IOrderExporterService orderExporterService;

    public TransactionProcessor(ITransactionReaderService  transactionReaderService, IOrderExporterService orderExporterService)
    {
        this.transactionReaderService = transactionReaderService;
        this.orderExporterService = orderExporterService;
    }


    /// <summary>
    /// This is the main ochestrator that collaborates with various dependencies to read and collate transactional 
    /// and meta data from underlying csv files
    /// and generate theree outputs (files) that are understood by three OMSs
    /// </summary>
    /// <param name="workingFolder"></param>
    /// <param name="transactionFile"></param>
    /// <returns></returns>
    public async Task ProcessAsync(string workingFolder, string transactionFile)
    {

        //load transactions with additional metatdata (portfolio & security) 
        var list = await transactionReaderService.ReadAsync(workingFolder, transactionFile);

        //export data compatible for various order systems
        foreach (var oms in Enum.GetValues(typeof(OMS)).Cast<OMS>())
            await orderExporterService.ExportAsync(list, workingFolder, oms);

    }
}
