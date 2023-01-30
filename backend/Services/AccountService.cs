namespace webapi.Services
{
    public class AccountService : IAccountService
    {
        private readonly JwtSettings _settings;

        private IPerson[] _persons;
        public AccountService(JwtSettings settings)
        {
            _settings = settings;
            _persons = new Resources.MockActiveDirectory().persons;
        }
        public IPerson FindOne(string userName)
        {
            return _persons.FirstOrDefault(p => string.Equals(p.sAMAccountName, userName, StringComparison.OrdinalIgnoreCase));
        }

        public bool Authenticate(string userName, string password)
        {
            try
            {
                var person = FindOne(userName);
                return string.Equals(person.password, password, StringComparison.Ordinal);
            }
            catch (Exception) { }
            return false;
        }

                public string GenerateJwtToken(string userId)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, userId)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _settings.Issuer,
                _settings.Audience,
                claims,
                expires: DateTime.UtcNow + _settings.Expire,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }


}