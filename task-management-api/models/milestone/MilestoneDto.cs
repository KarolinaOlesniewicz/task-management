using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class MilestoneDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<TaskDto> Tasks { get; set; }
}
