namespace Helpers
{

    [AttributeUsage(AttributeTargets.Property)]
    public class JsonCustomConverterAttribute : JsonConverterAttribute
    {
        private readonly string _serializationFormat;

        public JsonCustomConverterAttribute() : this(null) { }

        public JsonCustomConverterAttribute(string serializationFormat)
        {
            this._serializationFormat = serializationFormat ?? DateTimeCustomConverter.FormatDateTimeUTC;
        }

        public override JsonConverter CreateConverter(Type typeToConvert)
        {
            if (typeToConvert != typeof(DateTime) && typeToConvert != typeof(DateTime?))
                throw new Exception("Can only use this attribute on DateTime properties");

            return new DateTimeCustomConverter(_serializationFormat);
        }
    }
    public class DateTimeCustomConverter : JsonConverter<DateTime>
    {
        public const string FormatDate = "yyyy-MM-dd";
        public const string FormatDateTime = "yyyy-MM-dd HH:mm:ss";
        public const string FormatDateTimeUTC = "yyyy-MM-ddTHH:mm:ssZ";
        private readonly string _serializationFormat;
        public DateTimeCustomConverter() : this(null) { }

        public DateTimeCustomConverter(string serializationFormat)
        {
            this._serializationFormat = serializationFormat ?? FormatDateTime;
        }

        // Deserialization
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString() ?? string.Empty);
        }

        // Serialization
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            if (_serializationFormat == FormatDateTimeUTC)
                value = value.ToUniversalTime();
            writer.WriteStringValue(value.ToString(_serializationFormat));
        }
    }
}