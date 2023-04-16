namespace WellsFargo.Services.Export;

public interface IOrderExporterService
{
   Task ExportAsync(GenericList[] list, string workingFolder, OMS oms);
}