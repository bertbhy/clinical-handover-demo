namespace webapi.Services
{
    public interface IAccountService
    {
         IPerson FindOne(string userName);
         bool Authenticate(string userName, string password);

         string GenerateJwtToken(string userId);
    }
}