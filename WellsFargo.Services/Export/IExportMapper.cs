namespace WellsFargo.Services.Export
{
    public interface IExportMapper
    {
        IEnumerable<AAAList> MapAAA(GenericList[] list, string workingFolder);
        IEnumerable<BBBList> MapBBB(GenericList[] list, string workingFolder);
        IEnumerable<CCCList> MapCCC(GenericList[] list, string workingFolder);
    }
}