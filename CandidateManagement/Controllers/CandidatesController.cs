using CandidateManagement.Application.DTOs;
using CandidateManagement.Application.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CandidateManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateCandidate([FromBody] CandidateDto candidateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _candidateService.AddOrUpdateCandidateAsync(candidateDto));
        }
    }
}