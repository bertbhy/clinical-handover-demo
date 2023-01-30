namespace webapi.Services
{
    public interface IHandoverService
    {
        Task<Handover> GetHandover(Guid id);
        Task<Handover> GetHandover(string patientKey);
        Task<IEnumerable<HandoverGroup>> GetHandoverGroups();
        Task<IEnumerable<HandoverLog>> GetHandoverLog(string patientKey);
        Task<Handover> GetHandoverHistory(string patientKey, Guid log);
        Task<Handover> AddHandover(Handover handover);
        Task<Handover> UpdateHandover(Handover handover);
        Task DeleteHandover(Guid Id, string UserName);
        Task<GridQueryResponse<QueryHandoverResponse>> QueryHandover(IQueryCollection query, string specialtyCode, DateTime asof, string sortdatafield, string sortorder, int pagesize, int pagenum);
        Task<HandoverLog> AddHandoverLog(HandoverLog log);
        bool HandoverExists(string patientKey);
    }
}
