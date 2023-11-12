namespace StudentRecordSystem.Domain.Entities;

public class Course : BaseModel
{  
    public string CourseName { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
    public ICollection<Student> Students { get; set;} // nav prop for Student Entities
}
