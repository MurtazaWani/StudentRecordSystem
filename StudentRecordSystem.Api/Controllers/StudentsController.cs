using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRecordSystem.Application.Abstractions.IServices;
using StudentRecordSystem.Application.RRModels;
using System.Linq.Expressions;

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
    public async Task<ActionResult> Add([FromBody] StudentRequest studentRequest)
    {
        var res = await services.AddStudent(studentRequest);
        return Ok(res);
    }

    [HttpGet("id:guid")]
    public async Task<ActionResult> GetById(Guid id)
    {
        return default;
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateStudentRequest updateStudentRequest)
    {
        var res = await services.UpdateStudent(updateStudentRequest);
        return Ok(res);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        return null;
    }

    [HttpGet("{pageNo:int}/{pageSize:int}")]
    public async Task<ActionResult> FetchAll(int pageNo, int pageSize)
    {
        
        return default;
    }
}
