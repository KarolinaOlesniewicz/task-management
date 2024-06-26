using System;



namespace task_management_api.models.milestone
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class CreateMilestoneDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
