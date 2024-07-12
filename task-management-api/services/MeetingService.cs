using AutoMapper;
using Microsoft.EntityFrameworkCore;
using task_management_api.entities;
using task_management_api.exceptions;
using task_management_api.models.meeting;
using Task = System.Threading.Tasks.Task;

namespace task_management_api.services
{
    /// <summary>
    /// Defines an interface for meeting management services.
    /// This interface specifies methods for meeting operations like retrieval, creation, modification, and deletion.
    /// </summary>
    public interface IMeetingService
    {
        /// <summary>
        /// Retrieves all meetings for a specific board.
        /// </summary>
        /// <param name="userId">The ID of the user requesting the meetings.</param>
        /// <param name="workspaceId">The ID of the workspace containing the board.</param>
        /// <param name="boardId">The ID of the board whose meetings are to be retrieved.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of MeetingDto objects.</returns>
        Task<IEnumerable<MeetingDto>> GetAllMeetingsForBoard(int userId, int workspaceId, int boardId);

        /// <summary>
        /// Retrieves a specific meeting by its identifier.
        /// </summary>
        /// <param name="id">The ID of the meeting to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a MeetingDto object representing the meeting.</returns>
        Task<MeetingDto> GetMeetingById(int id);

        /// <summary>
        /// Creates a new meeting for a specific board.
        /// </summary>
        /// <param name="dto">The CreateMeetingDto object containing the data for the new meeting.</param>
        /// <param name="userId">The ID of the user creating the meeting.</param>
        /// <param name="workspaceId">The ID of the workspace containing the board.</param>
        /// <param name="boardId">The ID of the board to which the meeting will be added.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the ID of the newly created meeting.</returns>
        Task<int> CreateMeeting(CreateMeetingDto dto, int userId, int workspaceId, int boardId);

        /// <summary>
        /// Updates an existing meeting.
        /// </summary>
        /// <param name="id">The ID of the meeting to update.</param>
        /// <param name="dto">The MeetingDto object containing the updated data for the meeting.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdateMeeting(int id, MeetingDto dto);

        /// <summary>
        /// Deletes a specific meeting.
        /// </summary>
        /// <param name="id">The ID of the meeting to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteMeeting(int id);
    }

    /// <summary>
    /// Implements the IMeetingService interface, providing methods for meeting operations.
    /// </summary>
    public class MeetingService : IMeetingService
    {
        private readonly TaskManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the MeetingService class.
        /// </summary>
        /// <param name="dbContext">The database context for accessing data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping entities to DTOs.</param>
        public MeetingService(TaskManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<MeetingDto>> GetAllMeetingsForBoard(int userId, int workspaceId, int boardId)
        {
            var meetings = await _dbContext.Meetings
                .Include(m => m.Attendees)
                .Where(m => m.BoardId == boardId)
                .ToListAsync();

            var meetingDtos = _mapper.Map<IEnumerable<MeetingDto>>(meetings);
            return meetingDtos;
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public async Task<int> CreateMeeting(CreateMeetingDto dto, int userId, int workspaceId, int boardId)
        {
            var meeting = _mapper.Map<Meeting>(dto);
            meeting.CreatorId = userId;
            meeting.BoardId = boardId;

            _dbContext.Meetings.Add(meeting);
            await _dbContext.SaveChangesAsync();

            return meeting.Id;
        }

        /// <inheritdoc />
        public async Task UpdateMeeting(int id, MeetingDto dto)
        {
            var meeting = await _dbContext.Meetings.FindAsync(id);

            if (meeting == null)
                throw new NotFoundException("Meeting not found");

            _mapper.Map(dto, meeting);

            await _dbContext.SaveChangesAsync();
        }

        /// <inheritdoc />
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

