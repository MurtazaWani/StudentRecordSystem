using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRecordSystem.Domain.Entities;

public class BaseModel
{
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; } = Guid.NewGuid();
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
}
