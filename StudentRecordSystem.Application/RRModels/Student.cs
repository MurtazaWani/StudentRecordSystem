using StudentRecordSystem.Domain.Entities;

namespace StudentRecordSystem.Application.RRModels;

public class StudentRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int RollNo { get; set; }
    public Guid CourseId { get; set; }

}

public class StudentResponse : StudentRequest
{
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; } = Guid.NewGuid();
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
}
