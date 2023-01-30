namespace webapi.Models{
    public class HandoverLog
    {
        [Key]
        public Guid id { get; set; }

        [JsonCustomConverter(DateTimeCustomConverter.FormatDateTimeUTC)]
        public DateTime LogTime { get; set; }

        public string LogText { get; set; }

        public string LogBy { get; set; }

        public Guid HandoverId { get; set; }

    }
}