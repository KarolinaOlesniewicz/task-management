using AutoMapper;
using task_management_api.entities;
using task_management_api.models.workspace;

namespace task_management_api.services
{
    public interface IWorkspaceService
    {
        public IEnumerable<WorkspaceDisplayDto> GetAllByUserId(int userId);
        public WorkspaceDisplayDto getById(int userId, int workspaceId);
    }

    public class WorkspaceService :IWorkspaceService
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
            var workspaces = _dbContext.workspaces.FirstOrDefault(x => x.OwnerId == userId);
            var workspacesDtos = _mapper.Map<List<WorkspaceDisplayDto>>(workspaces);
            return workspacesDtos;
        }

        public WorkspaceDisplayDto getById(int userId,int workspaceId)
        {
            var workspace = _dbContext.workspaces.FirstOrDefault(x => x.OwnerId == userId && x.Id == workspaceId);
            var workspaceDto = _mapper.Map<WorkspaceDisplayDto>(workspace);
            return workspaceDto;

        }



    }
}
