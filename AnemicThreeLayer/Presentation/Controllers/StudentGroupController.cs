using Application.Dto;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Constants;
using Presentation.Models.StudentGroups;

namespace Presentation.Controllers;

[ApiController]
[Authorize(Policy = PolicyName.IsuPolicy)]
[Route("api/[controller]")]
public class StudentGroupController : ControllerBase
{
    private readonly IStudentGroupService _service;

    public StudentGroupController(IStudentGroupService service)
    {
        _service = service;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost]
    public async Task<ActionResult<StudentGroupDto>> CreateAsync([FromBody] CreateStudentGroupModel model)
    {
        StudentGroupDto group =
            await _service.CreateStudentGroupAsync(model.Name, model.MaxStudentCount, CancellationToken);
        return Ok(group);
    }
}