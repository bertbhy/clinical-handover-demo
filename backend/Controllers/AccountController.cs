
namespace webapi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest model)
        {
            if (ModelState.IsValid)
            {
                if (_accountService.Authenticate(model.Username, model.Password))
                {
                    var userProps = _accountService.FindOne(model.Username);
                    var response = new LoginResponse()
                    {
                        token = _accountService.GenerateJwtToken(userProps.sAMAccountName),
                        person = userProps
                    };

                    await SignInAsync(response);
                    return Ok(response);
                }
            }
            return BadRequest("Login failed");
        }

        [AllowAnonymous]
        [HttpGet("logout")]
        public async Task<ActionResult> Logout()
        {
            await SignOutAsync();
            return NoContent();
        }
    }

}
