using AutoMapper;
using task_management_api.entities;
using task_management_api.models.board;
using task_management_api.models.list;
using task_management_api.models.user;
using task_management_api.models.workspace;

namespace task_management_api.services
{
    public interface IWorkspaceService
    {
        public IEnumerable<WorkspaceDisplayDto> GetAllByUserId(int userId);
        public WorkspaceDisplayDto getById(int userId, int workspaceId);
        public int CreateWorkspace(int userId,CreateWorkspaceDto workspace);
        public bool DeleteWorkspace(int userId,int workspaceId);
        public bool EditWorkspace(int userId, int workspaceId, EditWorkspaceDto dto);
    }

    public class WorkspaceService : IWorkspaceService
    {
        private readonly TaskManagementDbContext _dbContext;
        private readonly IMapper _mapper;
        public WorkspaceService(TaskManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<WorkspaceDisplayDto> GetAllByUserId(int userId)
        {
            var workspaces = _dbContext.workspaces.Where(x => x.OwnerId == userId).ToList();
            var workspacesDtos = _mapper.Map<ICollection<WorkspaceDisplayDto>>(workspaces);
            return workspacesDtos;
        }

        public WorkspaceDisplayDto getById(int userId,int workspaceId)
        {
            var workspace = _dbContext.workspaces.FirstOrDefault(x => x.OwnerId == userId && x.Id == workspaceId);
            var workspaceDto = _mapper.Map<WorkspaceDisplayDto>(workspace);
            return workspaceDto;
        }

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
            _dbContext.workspaces.Add(workspace);
            _dbContext.SaveChanges();

            return workspace.Id;
        }

        public bool DeleteWorkspace(int userId, int workspaceId)
        {
            var workspace = _dbContext.workspaces
                            .FirstOrDefault(w => w.Id == workspaceId && w.OwnerId == userId);
            if (workspace is null)
            {
                return false;
            }

            _dbContext.workspaces.Remove(workspace);
            _dbContext.SaveChanges();
            return true;
        }

        public bool EditWorkspace(int userId,int workspaceId,EditWorkspaceDto dto)
        {
            var workspace = _dbContext.workspaces.FirstOrDefault(w => w.Id ==workspaceId && w.OwnerId == userId); 
            if (workspace is null) { return false; }

            var workspaceProperties = typeof(Workspace).GetProperties();
            var workspaceDtoProperties = typeof(EditWorkspaceDto).GetProperties();

            foreach (var dtoProperty in workspaceDtoProperties)
            {
                var workspaceProperty = workspaceProperties.FirstOrDefault(p => p.Name == dtoProperty.Name);

                var userValue = workspaceProperty.GetValue(workspace);
                var dtoValue = dtoProperty.GetValue(dto);

                if (userValue != dtoProperty)
                {
                    workspaceProperty.SetValue(workspace, dtoValue);
                }
            }
            _dbContext.SaveChanges();
            return true;
        }
    }
}
