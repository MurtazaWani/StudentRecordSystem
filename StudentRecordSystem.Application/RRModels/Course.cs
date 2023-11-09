using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRecordSystem.Application.RRModels;

public class CourseRequest
{
    public string CourseName { get; set; }
    public string Duration { get; set; }
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