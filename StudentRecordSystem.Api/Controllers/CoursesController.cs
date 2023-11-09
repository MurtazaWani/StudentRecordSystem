using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentRecordSystem.Application.Abstractions.IServices;
using StudentRecordSystem.Application.RRModels;

namespace StudentRecordSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly ICourseServices services;
    public CoursesController(ICourseServices services)
    {
        this.services = services;
    }
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var res = await services.GetCourses();
        return res.IsNullOrEmpty<CourseResponse>() ? BadRequest(res) : Ok(res);
    }

    [HttpPost]
    public async Task<ActionResult> Add(CourseRequest course)
    {
        var res = await services.AddCourse(course);
        return res is not null ? Ok(res) : BadRequest(res);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetById(Guid id)
    {
        var res = await services.GetCourseById(id);
        return res is not null ? Ok(res) : BadRequest(res);
    }

    [HttpPut]
    public async Task<ActionResult> Update(UpdateCourseRequest updateCourseRequest)
    {
        var res = await services.UpdateCourse(updateCourseRequest);
        return res is not null ? Ok(res) : BadRequest(res);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(Guid id)
    {
        var res = await services.DeleteCourse(id);
        return res > 0 ? Ok(res) : BadRequest(res);
    }
}
