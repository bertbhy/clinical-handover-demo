namespace webapi.Models
{
    public class QueryHandoverResponse : GetWardPatient
    {
        public QueryHandoverResponse(Handover h)
        {
            PatientKey = h.patientKey;
            PatientName = h.patientName;
            Dob = h.dob;
            Sex = h.sex;
            WardCode = h.wardCode;
            SpecialtyCode = h.specialtyCode;
            BedNumber = h.bedNumber;
            AdmissionTime = h.admissionTime;
            CaseNumber = h.caseNumber;
            GroupId = h.GroupId;
            GroupName = h?.Group?.GroupName;
        }
        public int? GroupId { get; set; }
        public string GroupName { get; set; }
    }
}