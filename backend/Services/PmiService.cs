namespace webapi.Services
{
    public class PmiService : IPmiService
    {
        private readonly dbContext _context;
        public PmiService(dbContext context)
        {
            _context = context;
        }
        public async Task<GridQueryResponse<GetWardPatient>> QueryPatient(IQueryCollection query, string specialtyCode, string sortdatafield, string sortorder, int pagesize, int pagenum)
        {
            var dbQuery = _context.GetWardPatients.FromSqlRaw(GridQuery.BuildQuery(query, "GetWardPatients")).Where(p => p.SpecialtyCode == specialtyCode);

            if (sortorder != null && sortorder != "")
            {
                dbQuery = dbQuery.OrderBy($"{sortdatafield} {sortorder}");
            }

            var dbResult = await dbQuery.ToListAsync();

            var total = dbResult.Count();
            var skip = pagesize * pagenum;
            if (skip >= total)
            {
                skip = 0;
            }
            var results = dbResult.Skip(skip).Take(pagesize);


            foreach (var r in results)
            {
                r.UpdateDate = null;
                var l = await _context.Handovers.Include(h => h.Log)
                       .FirstOrDefaultAsync(p => p.patientKey == r.PatientKey);
                if (l != null)
                {
                    var log = l.Log.OrderByDescending(l => l.LogTime).FirstOrDefault();
                    r.UpdateDate = log?.LogTime;
                }
            }

            return new GridQueryResponse<GetWardPatient>()
            {
                TotalRows = total,
                Rows = results
            };
        }
        public async Task<GetWardPatient> GetPatient(string patientKey)
        {
            return await _context.GetWardPatients.FirstOrDefaultAsync(p => p.PatientKey == patientKey);
        }
    }


}