using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRecordSystem.Domain.Entities;
public  class Student : BaseModel
{
    public string StudentName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public int RollNo { get; set; } = 0;

    public Guid CourseId { get; set; }


    #region Navigation

    [ForeignKey(nameof(CourseId))]
    public Course Course { get; set; } // ref nav prop for course entities

    #endregion
}
