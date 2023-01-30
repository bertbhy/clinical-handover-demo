namespace webapi.Services
{
    public interface IPerson
    {
        public string sAMAccountName { get; set; }
        public string displayName { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
    }
}