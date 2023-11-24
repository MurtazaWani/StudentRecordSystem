using System.Reflection;

namespace StudentRecordSystem.Domain.Entities;

// custom class to manage file-related operations.
// These operations could include tasks such as uploading files, downloading files,
// managing file storage, and handling file-related configurations.
public class AppFiles
{
    public string FilePath { get; set; } = null!;
    public Guid EntityId { get; set; }
    //public Module Module { get; set; }
}
