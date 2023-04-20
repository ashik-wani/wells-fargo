namespace WellsFargo.Services.Export
{
    public interface IExportMapper
    {
        IEnumerable<AAAList> MapAAA(GenericList[] list);
        IEnumerable<BBBList> MapBBB(GenericList[] list);
        IEnumerable<CCCList> MapCCC(GenericList[] list);
    }
}