

namespace webapi.Models
{
    public class Handover
    {
        [Key]
        public Guid id { get; set; }
        [MaxLength(32)]
        public string patientKey { get; set; }
        [MaxLength(48)]
        public string patientName { get; set; }
        [JsonCustomConverter(DateTimeCustomConverter.FormatDate)]
        public System.DateTime dob { get; set; }
        [MaxLength(1)]
        public string sex { get; set; }
        [MaxLength(4)]
        public string wardCode { get; set; }
        [MaxLength(4)]
        public string specialtyCode { get; set; }
        public string bedNumber { get; set; }
        [JsonCustomConverter(DateTimeCustomConverter.FormatDateTimeUTC)]
        public Nullable<System.DateTime> admissionTime { get; set; }
        [MaxLength(12)]
        public string caseNumber { get; set; }
        public string freeText { get; set; }
        public string diagnosis { get; set; }
        public string background { get; set; }
        public string progress { get; set; }
        public string ix { get; set; }
        public string drugs { get; set; }
        public string recommendation { get; set; }
        [MaxLength(20)]
        public string editedBy { get; set; }

        public int? GroupId { get; set; }
        [JsonIgnore]
        internal HandoverGroup Group { get; set; }
        public List<HandoverLog> Log { get; set; }

        internal string nameInitial
        {
            get
            {
                try
                {
                    string[] firstNameSplit = patientName.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                    string[] nameSplit = firstNameSplit[1].Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);

                    string initials = firstNameSplit[0] + ", ";

                    foreach (string item in nameSplit)
                    {
                        initials += item.Substring(0, 1).ToUpper() + " ";
                    }

                    return initials;
                }
                catch
                {
                    return patientName;
                }
            }
        }

     
    }
}
