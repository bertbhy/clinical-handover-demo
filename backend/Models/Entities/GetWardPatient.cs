
namespace webapi.Models
{
    public partial class GetWardPatient
    {
        [Key]
        [MaxLength(8)]
        public string PatientKey { get; set; }
        [Precision(0)]
        [JsonCustomConverter(DateTimeCustomConverter.FormatDateTimeUTC)]
        public DateTime? AdmissionTime { get; set; }
        [MaxLength(5)]
        public string BedNumber { get; set; }
        [MaxLength(12)]
        public string CaseNumber { get; set; }
        [JsonCustomConverter(DateTimeCustomConverter.FormatDate)]
        public DateTime Dob { get; set; }
        [JsonIgnore]
        [MaxLength(12)]
        internal string Hkid { get; set; }
        [MaxLength(100)]
        public string PatientName { get; set; }
        [MaxLength(1)]
        public string Sex { get; set; }
        [MaxLength(4)]
        public string SpecialtyCode { get; set; }
        [MaxLength(4)]
        public string WardCode { get; set; }
        [JsonCustomConverter(DateTimeCustomConverter.FormatDateTimeUTC)]
        public DateTime? UpdateDate { get; set; }
    }
}
