namespace webapi.Models
{
    public class LoginResponse
    {
        public string token {get;set;}
        public IPerson person { get; set; }
    }
}