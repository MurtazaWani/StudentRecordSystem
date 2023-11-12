using StudentRecordSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace StudentRecordSystem.Application.RRModels;

public class StudentRequest
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Roll number is required")]
    public int RollNo { get; set; } = 0;

    public Guid CourseId { get; set; }

}

public class StudentResponse : StudentRequest
{
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; } = Guid.NewGuid();
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
}

public class UpdateStudentRequest : StudentRequest
{
    public Guid Id { get; set; }
}