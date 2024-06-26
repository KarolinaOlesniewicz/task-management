using AutoMapper;
using Microsoft.EntityFrameworkCore;
using task_management_api.entities;
using task_management_api.exceptions;
using task_management_api.models.board;
using System.Collections.Generic;
using System.Threading.Tasks;
using task_management_api.models.meeting;
using Task = System.Threading.Tasks.Task;

namespace task_management_api.services
{
    public interface IMeetingService
    {
        Task<IEnumerable<MeetingDto>> GetAllMeetingsForBoard(int userId, int workspaceId, int boardId);
        Task<MeetingDto> GetMeetingById(int id);
        Task<int> CreateMeeting(CreateMeetingDto dto, int userId, int workspaceId, int boardId);
        Task UpdateMeeting(int id, MeetingDto dto);
        Task DeleteMeeting(int id);
    }

    public class MeetingService : IMeetingService
    {
        private readonly TaskManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        public MeetingService(TaskManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MeetingDto>> GetAllMeetingsForBoard(int userId, int workspaceId, int boardId)
        {
            var meetings = await _dbContext.Meetings
                .Include(m => m.Attendees)
                .Where(m => m.BoardId == boardId)
                .ToListAsync();

            var meetingDtos = _mapper.Map<IEnumerable<MeetingDto>>(meetings);
            return meetingDtos;
        }

        public async Task<MeetingDto> GetMeetingById(int id)
        {
            var meeting = await _dbContext.Meetings
                .Include(m => m.Attendees)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (meeting == null)
                throw new NotFoundException("Meeting not found");

            var meetingDto = _mapper.Map<MeetingDto>(meeting);
            return meetingDto;
        }

        public async Task<int> CreateMeeting(CreateMeetingDto dto, int userId, int workspaceId, int boardId)
        {
            var meeting = _mapper.Map<Meeting>(dto);
            meeting.CreatorId = userId;
            meeting.BoardId = boardId;

            _dbContext.Meetings.Add(meeting);
            await _dbContext.SaveChangesAsync();

            return meeting.Id;
        }

        public async Task UpdateMeeting(int id, MeetingDto dto)
        {
            var meeting = await _dbContext.Meetings.FindAsync(id);

            if (meeting == null)
                throw new NotFoundException("Meeting not found");

            _mapper.Map(dto, meeting);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMeeting(int id)
        {
            var meeting = await _dbContext.Meetings.FindAsync(id);

            if (meeting == null)
                throw new NotFoundException("Meeting not found");

            _dbContext.Meetings.Remove(meeting);
            await _dbContext.SaveChangesAsync();
        }
    }
}

