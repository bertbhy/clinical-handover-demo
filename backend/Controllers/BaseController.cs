
namespace webapi.Controllers
{
    public class BaseController : ControllerBase
    {
        public BaseController() : base()
        {

        }

        public string NameIdentifier
        {
            get
            {
                if (User == null || User.Claims == null)
                    return null;
                var nameIdentifier = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                return nameIdentifier?.Value;
            }
        }

        public IQueryCollection RequestQuery
        {
            get
            {
                if (Request == null || Request.Query == null)
                    return null;
                return Request.Query;
            }
        }

        internal async Task SignInAsync(LoginResponse response)
        {
            var userProps = response.person;
            var userClaims = new Claim[] { new Claim(ClaimTypes.Name, userProps.sAMAccountName) };
            var userClaimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(userClaims, JwtBearerDefaults.AuthenticationScheme));

            if (HttpContext != null)
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userClaimsPrincipal, new AuthenticationProperties() { });

            if (Response != null)
            {
                Response.Cookies.Append("X-Access-Token", response.token, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });
                Response.Cookies.Append("X-Username", userProps.sAMAccountName, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });
            }
        }

        internal async Task SignOutAsync()
        {
            if (Request != null)
                foreach (var cookie in Request.Cookies.Keys)
                {
                    Response.Cookies.Delete(cookie);
                }
            if (HttpContext != null)
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}