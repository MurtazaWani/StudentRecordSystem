using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRecordSystem.Application.RRModels;

public class CourseRequest
{
    [Required(ErrorMessage = "Name is required")]
    public string CourseName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Duration is required")]
    public string Duration { get; set; } = string.Empty;
}

public class CourseResponse : CourseRequest
{
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; } = Guid.NewGuid();
    public DateTimeOffset CreatedAt { get; set;} = DateTimeOffset.Now;
}

public class UpdateCourseRequest : CourseRequest
{
    public Guid Id { get; set; }
}