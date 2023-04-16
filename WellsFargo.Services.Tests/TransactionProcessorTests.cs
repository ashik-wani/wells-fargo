using WellsFargo.Services.Export;
using WellsFargo.Services.Types;

namespace WellsFargo.Services.Tests;

public class TransactionProcessorTests
{
    string workingFolder = $"{Environment.CurrentDirectory}\\Working";
    string transactionFile = "transactions.csv";

    public TransactionProcessor Service
    {
        get
        {
            //ideally i would spin up the IoC container and resolve this service
            return new TransactionProcessor(new TransactionReaderService(new CsvReadingService()), new OrderExporterService(new CsvWriteService(), new ExportMapper()));
        }
    }

    [Fact]
    public async Task ProcessShouldGenerateValidAAAFile()
    {
        //arrange
        var csvReadingService = new CsvReadingService();
        var service = this.Service;

        //act
        await service.ProcessAsync(workingFolder, transactionFile);

        //assert
        var aaaExpected = await csvReadingService.ReadAsync<AAAList>(Path.Combine(workingFolder, "aaaExpected.aaa"));
        var aaaActual = await csvReadingService.ReadAsync<AAAList>(Path.Combine(workingFolder, "aaa.aaa"));
        aaaExpected.Should().BeEquivalentTo(aaaActual);

    }

    [Fact]
    public async Task ProcessShouldGenerateValidBBBFile()
    {
        //arrange
        var service = this.Service;
        var csvReadingService = new CsvReadingService();

        //act
        await service.ProcessAsync(workingFolder, transactionFile);

        //assert
        var bbbExpected = await csvReadingService.ReadAsync<BBBList>(Path.Combine(workingFolder, "bbbExpected.bbb"), true, "|");
        var bbbActual = await csvReadingService.ReadAsync<BBBList>(Path.Combine(workingFolder, "bbb.bbb"), true, "|");

        bbbExpected.Should().BeEquivalentTo(bbbActual);

    }

    [Fact]
    public async Task ProcessShouldGenerateValidCCCFile()
    {
        //arrange
        var service = this.Service;
        var csvReadingService = new CsvReadingService();

        //act
        await service.ProcessAsync(workingFolder, transactionFile);

        //assert
        var cccExpected = await csvReadingService.ReadAsync<CCCList>(Path.Combine(workingFolder, "cccExpected.ccc"), false, ",");
        var cccActual = await csvReadingService.ReadAsync<CCCList>(Path.Combine(workingFolder, "ccc.ccc"), false, ",");
        cccExpected.Should().BeEquivalentTo(cccActual);

    }
}