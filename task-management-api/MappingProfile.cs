using AutoMapper;
using task_management_api.entities;
using task_management_api.models.board;
using task_management_api.models.list;
using task_management_api.models.tasks;
using task_management_api.models.user;
using task_management_api.models.workspace;
using task_management_api.models.meeting;
using task_management_api.models.milestone;


namespace task_management_api
{
    /// <summary>
    /// Defines a profile for AutoMapper configuration, specifying mappings between various data transfer objects (DTOs) and their corresponding entities.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Constructor that initialize mappings.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User,UserDto>();
            CreateMap<Workspace, WorkspaceDisplayDto>();
            CreateMap<List, ListDto>();
            CreateMap<entities.Task,TaskDto>();
            CreateMap<TaskDto,entities.Task>();

            CreateMap<WorkspaceMember,WorkspaceMemberDto>();

            CreateMap<CreateWorkspaceDto, Workspace>()
                .ForMember(w => w.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(w => w.Description, opt => opt.MapFrom(dto => dto.Description))
                .ForMember(w => w.Logo, opt => opt.MapFrom(dto => dto.Logo))
                .ForMember(w => w.Boards, opt => opt.MapFrom(dto => new List<Board>
                {
                    new Board
                    {
                        Name = dto.board.Name,
                        Description = dto.board.Description,
                        Background = dto.board.Background,
                        Lists = dto.board.Lists.Select(l => new List
                        {
                            Name = l.Name,
                            Position = l.Position
                        }).ToList()
                    }
                }));

            CreateMap<CreateBoardDto, Board>()
                .ForMember(b => b.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(b => b.Description, opt => opt.MapFrom(dto => dto.Description))
                .ForMember(b => b.Background, opt => opt.MapFrom(dto => dto.Background))
                .ForMember(b => b.Lists, opt => opt.MapFrom(dto => dto.Lists.Select(l => new List
                {
                    Name = l.Name,
                    Position = l.Position
                }).ToList()));

            CreateMap<CreateListDto, List>()
                .ForMember(l => l.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(l => l.Position, opt => opt.MapFrom(dto => dto.Position));

            CreateMap<CreateMeetingDto, Meeting>()
                .ForMember(m => m.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(m => m.Description, opt => opt.MapFrom(dto => dto.Description))
                .ForMember(m => m.Location, opt => opt.MapFrom(dto => dto.Location))
                .ForMember(m => m.Status, opt => opt.MapFrom(dto => dto.Status))
                .ForMember(m => m.StartDate, opt => opt.MapFrom(dto => dto.StartDate));

            CreateMap<MeetingDto, Meeting>();
            CreateMap<Meeting, MeetingDto>();

            //CreateMap<CreateMilestoneDto, Milestone>()
            //.ForMember(m => m.Name, opt => opt.MapFrom(dto => dto.Name))
            //.ForMember(m => m.Description, opt => opt.MapFrom(dto => dto.Description))
            //.ForMember(m => m.StartDate, opt => opt.MapFrom(dto => dto.StartDate))
            //.ForMember(m => m.EndDate, opt => opt.MapFrom(dto => dto.EndDate));

            //CreateMap<MilestoneDto, Milestone>();
            //CreateMap<Milestone, MilestoneDto>();

        }
    }
}
