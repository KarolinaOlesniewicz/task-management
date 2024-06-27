using AutoMapper;
using Microsoft.EntityFrameworkCore;
using task_management_api.entities;
using task_management_api.exceptions;
using task_management_api.models.list;
using task_management_api.models.workspace;

namespace task_management_api.services
{
    /// <summary>
    /// Defines an interface for workspace management services.
    /// This interface specifies methods for workspace operations like retrieval, creation, modification, and deletion.
    /// </summary>
    public interface IWorkspaceService
    {
        /// <summary>
        /// Retrieves a collection of all workspaces that a user is a member of.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An IEnumerable of WorkspaceDisplayDto objects representing all workspaces the user is a member of.</returns>
        IEnumerable<WorkspaceDisplayDto> GetAllByUserId(int userId);

        /// <summary>
        /// Retrieves a specific workspace data transfer object (DTO) by its identifier and checks if the user is a member.
        /// </summary>
        /// <param name="userId">The ID of the user who is a member of the workspace.</param>
        /// <param name="workspaceId">The unique identifier of the workspace to retrieve.</param>
        /// <returns>A WorkspaceDisplayDto object representing the workspace with the specified ID.</returns>
        WorkspaceDisplayDto getById(int userId, int workspaceId);

        /// <summary>
        /// Creates a new workspace and adds the user as a owner.
        /// </summary>
        /// <param name="userId">The ID of the user creating the workspace.</param>
        /// <param name="workspace">A CreateWorkspaceDto object containing the data for the new workspace.</param>
        /// <returns>The ID of the newly created workspace.</returns>
        int CreateWorkspace(int userId, CreateWorkspaceDto workspace);

        /// <summary>
        /// Deletes a specific workspace where the user is a owner.
        /// </summary>
        /// <param name="userId">The ID of the user who is a member of the workspace.</param>
        /// <param name="workspaceId">The ID of the workspace to delete.</param>
        void DeleteWorkspace(int userId, int workspaceId);

        /// <summary>
        /// Edits an existing workspace's data where the user is a owner.
        /// </summary>
        /// <param name="userId">The ID of the user who is a owner of the workspace.</param>
        /// <param name="workspaceId">The unique identifier of the workspace to edit.</param>
        /// <param name="dto">The EditWorkspaceDto object containing the updated data for the workspace.</param>
        void EditWorkspace(int userId, int workspaceId, EditWorkspaceDto dto);

        /// <summary>
        /// Retrieves all members of a specific workspace where the user is a member.
        /// </summary>
        /// <param name="userId">The ID of the user who is a member of the workspace.</param>
        /// <param name="workspaceId">The ID of the workspace whose members are to be retrieved.</param>
        /// <returns>A collection of WorkspaceMemberDto objects representing the workspace members.</returns>
        IEnumerable<WorkspaceMemberDto> GetAllWorkspaceMembers(int userId, int workspaceId);
    }

    /// <summary>
    /// Service implementation for managing workspaces.
    /// </summary>
    public class WorkspaceService : IWorkspaceService
    {
        private readonly TaskManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorkspaceService"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public WorkspaceService(TaskManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public IEnumerable<WorkspaceDisplayDto> GetAllByUserId(int userId)
        {
            var workspaces = _dbContext.Workspaces.Where(x => x.OwnerId == userId).ToList();
            var workspacesDtos = _mapper.Map<ICollection<WorkspaceDisplayDto>>(workspaces);
            return workspacesDtos;
        }

        /// <inheritdoc/>
        public WorkspaceDisplayDto getById(int userId,int workspaceId)
        {
            var workspace = _dbContext.Workspaces.FirstOrDefault(x => x.OwnerId == userId && x.Id == workspaceId);
            if (workspace is null)
            {
                throw new NotFoundException("Workspace not Found");
            }
            var workspaceDto = _mapper.Map<WorkspaceDisplayDto>(workspace);
            return workspaceDto;
        }

        /// <inheritdoc/>
        public int CreateWorkspace(int userId, CreateWorkspaceDto workspaceDto)
        {
            var Lists = new List<CreateListDto>
            {
                 new CreateListDto()
                {
                    Name = "To Do",
                    Position = 1
                },
                new CreateListDto()
                {
                    Name = "In Progress",
                    Position = 2
                },
                new CreateListDto()
                {
                    Name = "Done",
                    Position = 3
                }
            };

            workspaceDto.board.Lists = Lists;

            var workspace = _mapper.Map<Workspace>(workspaceDto);
            workspace.OwnerId = userId;
            _dbContext.Workspaces.Add(workspace);
            _dbContext.SaveChanges();

            return workspace.Id;
        }

        /// <inheritdoc/>
        public void DeleteWorkspace(int userId, int workspaceId)
        {
            var workspace = _dbContext.Workspaces
                            .FirstOrDefault(w => w.Id == workspaceId && w.OwnerId == userId);
            if (workspace is null)
            {
                throw new NotFoundException("Workspace not Found");
            }


            _dbContext.Workspaces.Remove(workspace);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public void EditWorkspace(int userId,int workspaceId,EditWorkspaceDto dto)
        {
            var workspace = _dbContext.Workspaces.FirstOrDefault(w => w.Id ==workspaceId && w.OwnerId == userId);

            if (workspace is null) { throw new NotFoundException("Workspace not Found"); }

            workspace = (Workspace)ReflectionService.Reflect(dto, workspace);

            //if (workspace is null) { return false; }

            //var workspaceProperties = typeof(Workspace).GetProperties();
            //var workspaceDtoProperties = typeof(EditWorkspaceDto).GetProperties();

            //foreach (var dtoProperty in workspaceDtoProperties)
            //{
            //    var workspaceProperty = workspaceProperties.FirstOrDefault(p => p.Name == dtoProperty.Name);

            //    var userValue = workspaceProperty.GetValue(workspace);
            //    var dtoValue = dtoProperty.GetValue(dto);

            //    if (userValue != dtoProperty)
            //    {
            //        workspaceProperty.SetValue(workspace, dtoValue);
            //    }
            //}
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public IEnumerable<WorkspaceMemberDto> GetAllWorkspaceMembers(int userId,int workspaceId)
        {
            var workspace = _dbContext.Workspaces.Include(r => r.WorkspaceMembers).FirstOrDefault(r => r.OwnerId == userId && r.Id == workspaceId);

            if(workspace is null) { throw new NotFoundException("Workspace not Found"); }

            var members = workspace.WorkspaceMembers.ToList();

            var membersDtos = _mapper.Map<List<WorkspaceMemberDto>>(members);

            return membersDtos;
        }
    }
}
