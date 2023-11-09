namespace StudentRecordSystem.Domain.Entities;

public class Course : BaseModel
{  
    public string CourseName {get; set;}
    public string Duration { get; set;}
    public ICollection<Student> Students { get; set;} // nav prop for Student Entities
}
