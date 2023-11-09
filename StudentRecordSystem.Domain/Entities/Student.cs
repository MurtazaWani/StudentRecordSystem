using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRecordSystem.Domain.Entities;
public  class Student : BaseModel
{
    public string StudentName { get; set; }

    public string Email { get; set; }

    public int RollNo { get; set; }

    public Guid CourseId { get; set; }


    #region Navigation

    [ForeignKey(nameof(CourseId))]
    public Course Course { get; set; } // ref nav prop for course entities

    #endregion
}
