namespace webapi.Services
{
    public interface IPmiService{

        Task<GridQueryResponse<GetWardPatient>> QueryPatient(IQueryCollection query, string specialtyCode, string sortdatafield, string sortorder, int pagesize, int pagenum);
        Task<GetWardPatient> GetPatient(string patientKey);
    }
}