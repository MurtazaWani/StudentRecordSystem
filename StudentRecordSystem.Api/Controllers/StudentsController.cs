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
        return res != null ? Ok(res) : BadRequest("invalid student");
    }

    [HttpGet("id:guid")]
    public async Task<ActionResult> GetById(Guid id)
    {
        var res = await services.GetStudentById(id);
        return res != null ? Ok(res) : NotFound("student not found");
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateStudentRequest updateStudentRequest)
    {
        var res = await services.UpdateStudent(updateStudentRequest);
        return res != null ? Ok(res) : BadRequest("invalid student");
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var res = await services.DeleteStudent(id);
        return res > 0 ? Ok(res) : BadRequest("failed");
    }

    [HttpGet("{pageNo:int}/{pageSize:int}")]
    public async Task<ActionResult> FetchAll(int pageNo, int pageSize)
    {
        var res = await services.FetchAllAsync(pageNo, pageSize);
        return res != null ? Ok(res) : BadRequest("there is some issue");
    }

    [HttpGet("{name:alpha}")]
    public async Task<ActionResult> GetStudentByName(string name)
    {
        var res = await services.GetStudentByName(name);
        return res != null ? Ok(res) : NotFound("does not exist");
    }
}
