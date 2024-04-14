using AutoMapper;
using task_management_api.entities;
using task_management_api.models.user;
using task_management_api.models.workspace;

namespace task_management_api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<Workspace, WorkspaceDisplayDto>();  
        }
    }
}
