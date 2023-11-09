using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRecordSystem.Application.Abstractions.IServices;
using StudentRecordSystem.Application.RRModels;

namespace StudentRecordSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentServices services;

    public StudentsController(IStudentServices services)
    {
        this.services = services;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var res = await services.GetStudents();
        return Ok(res);
    }

    [HttpPost]
    public async Task<ActionResult> Add(StudentRequest studentRequest)
    {
        var res = await services.AddStudent(studentRequest);
        return Ok(res);
    }

    [HttpGet("{pageNo:int}/{pageSize:int}")]
    public async Task<ActionResult> FetchAll(int pageNo, int pageSize)
    {
        return default;
    }
}
