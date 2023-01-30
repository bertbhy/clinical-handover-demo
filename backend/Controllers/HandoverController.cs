
namespace webapi.Controllers
{

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class HandoverController : BaseController
    {
        private readonly IHandoverService _handoverService;

        public HandoverController(IHandoverService handoverService)
        {
            _handoverService = handoverService;
        }

        [HttpGet("{patientKey}")]
        public async Task<ActionResult<Handover>> GetHandover(string patientKey)
        {
            var handover = await _handoverService.GetHandover(patientKey);
            if (handover == null)
                return NotFound();
            return Ok(handover);
        }

        [HttpGet("groups")]
        public async Task<ActionResult<IEnumerable<HandoverGroup>>> GetHandoverGroups()
        {
            var groups = await _handoverService.GetHandoverGroups();
            if (groups == null)
                return NotFound();
            return Ok(groups);
        }

        [HttpGet("log/{patientKey}")]
        public async Task<ActionResult<IEnumerable<HandoverLog>>> GetHandoverLog(string patientKey)
        {
            var logs = await _handoverService.GetHandoverLog(patientKey);
            if (logs == null)
                return NotFound();
            return Ok(logs);
        }

        [HttpGet("history/{patientKey}")]
        public async Task<ActionResult<Handover>> GetHandoverHistory(string patientKey, Guid log)
        {
            var history = await _handoverService.GetHandoverHistory(patientKey, log);
            if (history == null)
                return NotFound();
            return Ok(history);
        }

        [HttpPost]
        public async Task<ActionResult<Handover>> PostHandover(Handover handover, int? groupId)
        {
            handover.GroupId = groupId;
            handover.editedBy = NameIdentifier;

            if (_handoverService.HandoverExists(handover.patientKey))
            {
                handover = await _handoverService.UpdateHandover(handover);
            }
            else
            {
                handover = await _handoverService.AddHandover(handover);
            }
            return CreatedAtAction("GetHandover", new { id = handover.id }, handover);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> DeleteHandover(Guid id)
        {
            await _handoverService.DeleteHandover(id, NameIdentifier);
            return NoContent();
        }


        [HttpGet("QueryHandover")]
        public async Task<ActionResult<GridQueryResponse<QueryHandoverResponse>>> QueryHandover(string specialtyCode, DateTime asof, string sortdatafield, string sortorder, int pagesize, int pagenum)
        {
            var result = await _handoverService.QueryHandover(RequestQuery, specialtyCode, asof, sortdatafield, sortorder, pagesize, pagenum);
            return Ok(result);
        }
    }
}


