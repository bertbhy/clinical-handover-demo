
namespace webapi.Models
{
    // dotnet ef migrations add 3_tosingle --context dbContext
    // dotnet ef migrations remove --context dbContext
    // dotnet ef database update --context dbContext --configuration debug|release
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
                .Entity<Handover>()
                .HasOne(b => b.Group)
                .WithMany()
                .HasForeignKey(h => h.GroupId);

            modelBuilder
                .Entity<Handover>()
                .HasMany(b => b.Log)
                .WithOne()
                .HasForeignKey(h => h.HandoverId);

            modelBuilder
                .Entity<Handover>()
                .ToTable("Handover", b => b.IsTemporal());

            var mockData = new Resources.MockData();
            modelBuilder.Entity<HandoverGroup>().HasData(mockData.HandoverGroups);
            modelBuilder.Entity<GetWardPatient>().HasData(mockData.GetWardPatients);
            modelBuilder.Entity<Handover>().HasData(mockData.Handovers);
            modelBuilder.Entity<HandoverLog>().HasData(mockData.HandoverLogs);
        }

        private void mockHandoverPatient(Handover h, GetWardPatient p)
        {
            h.patientKey = p.PatientKey;
            h.patientName = p.PatientName;
            h.dob = p.Dob;
            h.sex = p.Sex;
            h.wardCode = p.WardCode;
            h.specialtyCode = p.SpecialtyCode;
            h.bedNumber = p.BedNumber;
            h.admissionTime = p.AdmissionTime;
            h.caseNumber = p.CaseNumber;
        }

        public DbSet<Handover> Handovers { get; set; }
        public DbSet<HandoverLog> HandoverLogs { get; set; }
        public DbSet<HandoverGroup> HandoverGroups { get; set; }
        public virtual DbSet<GetWardPatient> GetWardPatients { get; set; }
    }
}
