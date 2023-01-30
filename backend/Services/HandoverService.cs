namespace webapi.Services
{
    public class HandoverService : IHandoverService
    {
        private readonly dbContext _context;
        public HandoverService(dbContext context)
        {
            _context = context;
        }
        public async Task<Handover> GetHandover(Guid id)
        {
            return await _context.Handovers.FirstOrDefaultAsync(p => p.id == id);
        }
        public async Task<Handover> GetHandover(string patientKey)
        {
            return await _context.Handovers.FirstOrDefaultAsync(p => p.patientKey == patientKey);
        }
        public async Task<IEnumerable<HandoverLog>> GetHandoverLog(string patientKey)
        {
            var handover = await _context.Handovers.Include(h => h.Log).FirstOrDefaultAsync(p => p.patientKey == patientKey);
            if (handover == null)
                return new List<HandoverLog>();
            return handover.Log.OrderByDescending(l => l.LogTime).Take(10).ToList();
        }
        public async Task<Handover> GetHandoverHistory(string patientKey, Guid log)
        {
            var handoverlog = await _context.HandoverLogs.FindAsync(log);
            var handover = await _context.Handovers
                       .TemporalAsOf(handoverlog.LogTime.AddSeconds(2).ToUniversalTime())
                       .SingleOrDefaultAsync(p => p.patientKey == patientKey);
            if (handover == null)
                handover = await GetHandover(patientKey);
            return handover;
        }
        public async Task<Handover> AddHandover(Handover handover)
        {
            var entry = _context.Handovers.Add(handover);
            await _context.SaveChangesAsync();
            var log = new HandoverLog()
            {
                HandoverId = entry.Entity.id,
                LogTime = DateTime.Now.ToUniversalTime(),
                LogBy = handover.editedBy,
                LogText = "New"
            };
            await AddHandoverLog(log);
            return entry.Entity;
        }
        public async Task<Handover> UpdateHandover(Handover handover)
        {
            handover.id = (await _context.Handovers.AsNoTracking().FirstAsync(h => h.patientKey == handover.patientKey)).id;
            _context.Entry(handover).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var log = new HandoverLog()
            {
                HandoverId = handover.id,
                LogTime = DateTime.Now.ToUniversalTime(),
                LogBy = handover.editedBy,
                LogText = "Update"
            };
            await AddHandoverLog(log);
            return handover;
        }
        public async Task DeleteHandover(Guid Id, string UserName)
        {
            var handover = await GetHandover(Id);
            handover.editedBy = null;
            await _context.SaveChangesAsync();

            var log = new HandoverLog()
            {
                HandoverId = handover.id,
                LogTime = DateTime.Now.ToUniversalTime(),
                LogBy = UserName,
                LogText = "Delete"
            };
            await AddHandoverLog(log);
        }
        public bool HandoverExists(string patientKey)
        {
            return _context.Handovers.Any(e => e.patientKey == patientKey);
        }
        public async Task<GridQueryResponse<QueryHandoverResponse>> QueryHandover(IQueryCollection query, string specialtyCode, DateTime asof, string sortdatafield, string sortorder, int pagesize, int pagenum)
        {
            var dbQuery = _context.Handovers
            .FromSqlRaw(GridQuery.BuildQuery(query, $@"Handover  FOR SYSTEM_TIME as of '{asof.Date.AddDays(1).ToString("o")}'", "*"))
            .Where(h => h.editedBy != null && h.specialtyCode == specialtyCode);

            if (sortorder != null && sortorder != "")
            {
                dbQuery = dbQuery.OrderBy($"{sortdatafield} {sortorder}");
            }

            var dbResult = await dbQuery.ToListAsync();

            var total = dbResult.Count();
            var skip = pagesize * pagenum;
            if (skip >= total)
                skip = 0;
            var keys = dbResult.Skip(skip).Take(pagesize).Select(h => h.patientKey).ToList();
            var results = new List<QueryHandoverResponse>();
            foreach (var r in keys)
            {
                var l = await _context.Handovers.AsNoTracking().Include(h => h.Log).Include(h => h.Group)
                       .FirstOrDefaultAsync(p => p.patientKey == r);
                if (l != null)
                {
                    var q = new QueryHandoverResponse(l);
                    q.UpdateDate = null;
                    q.UpdateDate = l.Log.OrderByDescending(l => l.LogTime).FirstOrDefault()?.LogTime;
                    results.Add(q);
                }
            }

            return new GridQueryResponse<QueryHandoverResponse>()
            {
                TotalRows = total,
                Rows = results
            };
        }
        public async Task<HandoverLog> AddHandoverLog(HandoverLog log)
        {
            await Task.Delay(500);
            var entry = _context.HandoverLogs.Add(log);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<IEnumerable<HandoverGroup>> GetHandoverGroups()
        {
          return await _context.HandoverGroups.ToListAsync();
        }
    }
}