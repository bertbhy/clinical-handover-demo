
namespace webapi.Resources
{
    public class MockData
    {

        public List<Handover> Handovers { get; set; }
        public List<HandoverLog> HandoverLogs { get; set; }
        public List<HandoverGroup> HandoverGroups { get; set; }
        public List<GetWardPatient> GetWardPatients { get; set; }

        public MockData()
        {

            HandoverGroups = new List<HandoverGroup>(){
                new HandoverGroup() { Id = 1, GroupName = "Oncology Handover", SpecialtyCode = "ONC" },
                new HandoverGroup() { Id = 2, GroupName = "Nephrology Handover", SpecialtyCode = "REN" }
           };

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            GetWardPatients = new List<GetWardPatient>();
            using (StreamReader r = new StreamReader(Directory.GetCurrentDirectory() + @"/Resources/mockPatient3S.json"))
            {
                var mockData = JsonSerializer.Deserialize<GetWardPatient[]>(r.ReadToEnd(), options);
                GetWardPatients.AddRange(mockData);
            }
            using (StreamReader r = new StreamReader(Directory.GetCurrentDirectory() + @"/Resources/mockPatient5N.json"))
            {
                var mockData = JsonSerializer.Deserialize<GetWardPatient[]>(r.ReadToEnd(), options);
                GetWardPatients.AddRange(mockData);
            }
            Handovers = new List<Handover>();
            using (StreamReader l = new StreamReader(Directory.GetCurrentDirectory() + @"/Resources/mockHandoverLog.json"))
            using (StreamReader o = new StreamReader(Directory.GetCurrentDirectory() + @"/Resources/mockHandoverONC.json"))
            using (StreamReader r = new StreamReader(Directory.GetCurrentDirectory() + @"/Resources/mockHandoverREN.json"))
            {
                var mockHanoverLog = JsonSerializer.Deserialize<HandoverLog[]>(l.ReadToEnd(), options);
                var mockHanoverONC = JsonSerializer.Deserialize<Handover[]>(o.ReadToEnd(), options);
                var mockHanoverREN = JsonSerializer.Deserialize<Handover[]>(r.ReadToEnd(), options);
                mockHanoverONC = mockHanoverONC.Take(30).ToArray();
                mockHanoverREN = mockHanoverREN.Take(30).ToArray();
                for (int i = 0; i < 30; i++)
                {
                    mockHanoverONC[i].id = mockHanoverLog[i].HandoverId;
                    mockHanoverONC[i].editedBy = mockHanoverLog[i].LogBy;
                    mockHanoverONC[i].GroupId = 1;
                    mockHandoverPatient(mockHanoverONC[i], GetWardPatients[i]);

                    mockHanoverREN[i].id = mockHanoverLog[i + 30].HandoverId;
                    mockHanoverREN[i].editedBy = mockHanoverLog[i].LogBy;
                    mockHanoverREN[i].GroupId = 2;
                    mockHandoverPatient(mockHanoverREN[i], GetWardPatients[i + 30]);
                }
                Handovers.AddRange(mockHanoverONC);
                Handovers.AddRange(mockHanoverREN);
                HandoverLogs = new List<HandoverLog>();
                HandoverLogs.AddRange(mockHanoverLog);
            }
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
    }
}