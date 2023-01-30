
namespace webapi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PmiController : BaseController
    {
        private readonly IPmiService _pmiService;

        public PmiController(IPmiService pmiService)
        {
            _pmiService = pmiService;
        }
        [HttpGet("patient")]
        public async Task<ActionResult<GetWardPatient>> GetPatient(string patientKey)
        {
            var pmi = await _pmiService.GetPatient(patientKey);
            if (pmi == null)
                return NotFound();
            return Ok(pmi);
        }

        [HttpGet("QueryPatient")]
        public async Task<ActionResult<GridQueryResponse<GetWardPatient>>> QueryPatient(string specialtyCode, string sortdatafield, string sortorder, int pagesize, int pagenum)
        {
            var result = await _pmiService.QueryPatient(RequestQuery, specialtyCode, sortdatafield, sortorder, pagesize, pagenum);
            return Ok(result);
        }

    }
}
