﻿using Microsoft.AspNetCore.Http;
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
        return res.IsNullOrEmpty() ? BadRequest(res) : Ok(res);
    }
    
    [HttpPost]
    public async Task<ActionResult> Add([FromBody] CourseRequest course)
    {
        var res = await services.AddCourse(course);
        return res is not null ? Ok(res) : BadRequest(res);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetById(Guid id)
    {
        var res = await services.GetCourseById(id);
        return res is not null ? Ok(res) : NotFound("not found");
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateCourseRequest updateCourseRequest)
    {
        var res = await services.UpdateCourse(updateCourseRequest);
        return res is not null ? Ok(res) : BadRequest(res);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var res = await services.DeleteCourse(id);
        return res > 0 ? Ok(res) : BadRequest(res);
    }

    [HttpGet("{name:alpha}")]
    public async Task<ActionResult> GetByName(string name)
    {
        var res = await services.GetCourseByName(name);
        return res != null ? Ok(res) : BadRequest("does not exist");
    }

    [HttpGet("{pageNo:int}/{pageSize:int}")]
    public async Task<ActionResult> FetchAll(int pageNo, int pageSize)
    {
        var res = await services.FetchAllAsync(pageNo, pageSize);
        return res != null ? Ok(res) : BadRequest("there is some issue");
    }
}
