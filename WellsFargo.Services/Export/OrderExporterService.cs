using WellsFargo.Services.Types;

namespace WellsFargo.Services.Export;

public class OrderExporterService : IOrderExporterService
{
    private readonly ICsvWriteService csvWriteService;
    private readonly IExportMapper exportMapper;

    public OrderExporterService(ICsvWriteService csvWriteService, IExportMapper exportMapper)
    {
        this.csvWriteService = csvWriteService;
        this.exportMapper = exportMapper;
    }

    public async Task ExportAsync(GenericList[] list, string workingFolder, OMS oms)
    {
        switch (oms)
        {
            case OMS.AAA:
               var aaaList = exportMapper.MapAAA(list);
               await csvWriteService.WriteAsync(workingFolder, $"aaa.{OMS.AAA}", aaaList);
                break;
            case OMS.BBB:
                var bbblist = exportMapper.MapBBB(list);
                await csvWriteService.WriteAsync(workingFolder, $"bbb.{OMS.BBB}", bbblist, true, "|");
                break;
            case OMS.CCC:
                var cccList = exportMapper.MapCCC(list);
                await csvWriteService.WriteAsync(workingFolder, $"ccc.{OMS.CCC}", cccList, false);
                break;
            default:
                break;
        }
    }  
}