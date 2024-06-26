using AutoMapper;
using Microsoft.EntityFrameworkCore;
using task_management_api.entities;
using task_management_api.exceptions;
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
        public void DeleteWorkspace(int userId,int workspaceId);
        public void EditWorkspace(int userId, int workspaceId, EditWorkspaceDto dto);
        public IEnumerable<WorkspaceMemberDto> GetAllWorkspaceMembers(int userId, int workspaceId);
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
            var workspaces = _dbContext.Workspaces.Where(x => x.OwnerId == userId).ToList();
            var workspacesDtos = _mapper.Map<ICollection<WorkspaceDisplayDto>>(workspaces);
            return workspacesDtos;
        }

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

        public IEnumerable<WorkspaceMemberDto> GetAllWorkspaceMembers(int userId,int workspaceId)
        {
            var workspace = _dbContext.workspaces.Include(r => r.WorkspaceMembers).FirstOrDefault(r => r.OwnerId == userId && r.Id == workspaceId);

            if(workspace is null) { throw new NotFoundException("Workspace not Found"); }

            var members = workspace.WorkspaceMembers.ToList();

            var membersDtos = _mapper.Map<List<WorkspaceMemberDto>>(members);

            return membersDtos;
        }
    }
}
