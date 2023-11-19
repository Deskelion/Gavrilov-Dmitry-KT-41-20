using GavrilovDmitryKT_41_20.Interfaces.SubjectInterfaces;
using GavrilovDmitryKT_41_20.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GavrilovDmitryKT_41_20.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ILogger<SubjectController> logger;
        private readonly ISubjectService _subjectService;

        public SubjectController(ILogger<SubjectController> logger, ISubjectService subjectService)
        {
            this.logger = logger;
            _subjectService = subjectService;
        }

        [HttpPost("GetSubject")]
        public async Task<IActionResult> GetSubjectAsync(CancellationToken cancellationToken = default)
        {
            var subjects = await _subjectService.GetSubjectAsync(cancellationToken);
            return Ok(subjects);
        }

        [HttpPost("Add subjects")]
        [ActionName(nameof(AddSubjectAsync))]
        public async Task<IActionResult> AddSubjectAsync(Subject subject, CancellationToken cancellationToken = default)
        {
            await _subjectService.AddSubjectAsync(subject, cancellationToken);
            return CreatedAtAction(nameof(AddSubjectAsync), new { id = subject.Id }, subject);
        }

        [HttpPut("Update subjects")]
        public async Task<IActionResult> UpdateSubjectAsync(int id, Subject subject, CancellationToken cancellationToken = default)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }
            await _subjectService.UpdateSubjectAsync(subject, cancellationToken);
            return NoContent();
        }

        [HttpDelete("Delete subjects")]
        public async Task<IActionResult> DeleteStudentAsync(int id, CancellationToken cancellationToken = default)
        {
            var subject = await _subjectService.GetSubjectAsync(id, cancellationToken);

            if (subject == null)
            {
                return NotFound();
            }
            await _subjectService.DeleteSubjectAsync(subject, cancellationToken);
            return Ok(subject);
        }
    }
}
