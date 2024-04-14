namespace task_management_api.models.list
{
    public class WorkspaceListInitializer
    {
        //public WorkspaceListInitializer()
        //{
        //    this.Lists = new List<CreateListDto>
        //    {
        //         new CreateListDto()
        //        {
        //            Name = "To Do",
        //            Position = 1
        //        },
        //        new CreateListDto()
        //        {
        //            Name = "In Progress",
        //            Position = 2
        //        },
        //        new CreateListDto()
        //        {
        //            Name = "Done",
        //            Position = 3
        //        }

        //    };
        //}
        public ICollection<CreateListDto>  Lists { get; set; }
    }
}
