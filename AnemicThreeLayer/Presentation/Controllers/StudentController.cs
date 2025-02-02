using Application.Dto;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Constants;
using Presentation.Models.Students;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = PolicyName.FacultyPolicy)]
public class StudentController : ControllerBase
{
    private readonly IStudentService _service;

    public StudentController(IStudentService service)
    {
        _service = service;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost]
    public async Task<ActionResult<StudentDto>> CreateAsync([FromBody] CreateStudentModel model)
    {
        StudentDto student = await _service.CreateStudentAsync(model.Name, model.GroupId, CancellationToken);
        return Ok(student);
    }
}