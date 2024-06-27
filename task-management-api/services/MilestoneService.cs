using AutoMapper;
using Microsoft.EntityFrameworkCore;
using task_management_api.entities;
using task_management_api.exceptions;
using task_management_api.models.milestone;
using Task = System.Threading.Tasks.Task;

namespace task_management_api.services
{
    /// <summary>
    /// Defines an interface for milestone management services.
    /// This interface specifies methods for milestone operations like retrieval, creation, modification, and deletion.
    /// </summary>
    public interface IMilestoneService
    {
        /// <summary>
        /// Retrieves all milestones for a specific board.
        /// </summary>
        /// <param name="userId">The ID of the user requesting the milestones.</param>
        /// <param name="workspaceId">The ID of the workspace containing the board.</param>
        /// <param name="boardId">The ID of the board whose milestones are to be retrieved.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of MilestoneDto objects.</returns>
        Task<IEnumerable<MilestoneDto>> GetAllMilestonesForBoard(int userId, int workspaceId, int boardId);

        /// <summary>
        /// Retrieves a specific milestone by its identifier.
        /// </summary>
        /// <param name="milestoneId">The ID of the milestone to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a MilestoneDto object representing the milestone.</returns>
        Task<MilestoneDto> GetMilestoneById(int milestoneId);

        /// <summary>
        /// Adds a new milestone to a specific board.
        /// </summary>
        /// <param name="dto">The CreateMilestoneDto object containing the data for the new milestone.</param>
        /// <param name="boardId">The ID of the board to which the milestone will be added.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddMilestoneForBoard(CreateMilestoneDto dto, int boardId);

        /// <summary>
        /// Updates an existing milestone.
        /// </summary>
        /// <param name="milestoneId">The ID of the milestone to update.</param>
        /// <param name="dto">The CreateMilestoneDto object containing the updated data for the milestone.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdateMilestone(int milestoneId, CreateMilestoneDto dto);

        /// <summary>
        /// Deletes a specific milestone.
        /// </summary>
        /// <param name="milestoneId">The ID of the milestone to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteMilestone(int milestoneId);
    }

    /// <summary>
    /// Implements the IMilestoneService interface, providing methods for milestone operations.
    /// </summary>
    public class MilestoneService : IMilestoneService
    {
        private readonly TaskManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the MilestoneService class.
        /// </summary>
        /// <param name="dbContext">The database context for accessing data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping entities to DTOs.</param>
        public MilestoneService(TaskManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<MilestoneDto>> GetAllMilestonesForBoard(int userId, int workspaceId, int boardId)
        {
            var board = await _dbContext.Boards
                .Include(b => b.Milestones)
                .FirstOrDefaultAsync(b => b.Id == boardId);

            if (board == null)
                throw new NotFoundException("Board not found");

            var milestones = _mapper.Map<IEnumerable<MilestoneDto>>(board.Milestones);
            return milestones;
        }

        /// <inheritdoc />
        public async Task<MilestoneDto> GetMilestoneById(int milestoneId)
        {
            var milestone = await _dbContext.Milestones.FindAsync(milestoneId);

            if (milestone == null)
                throw new NotFoundException("Milestone not found");

            var milestoneDto = _mapper.Map<MilestoneDto>(milestone);
            return milestoneDto;
        }

        /// <inheritdoc />
        public async Task AddMilestoneForBoard(CreateMilestoneDto dto, int boardId)
        {
            var milestone = _mapper.Map<Milestone>(dto);
            milestone.BoardId = boardId;

            _dbContext.Milestones.Add(milestone);
            await _dbContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task UpdateMilestone(int milestoneId, CreateMilestoneDto dto)
        {
            var milestone = await _dbContext.Milestones.FindAsync(milestoneId);

            if (milestone == null)
                throw new NotFoundException("Milestone not found");

            _mapper.Map(dto, milestone);

            await _dbContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DeleteMilestone(int milestoneId)
        {
            var milestone = await _dbContext.Milestones.FindAsync(milestoneId);

            if (milestone == null)
                throw new NotFoundException("Milestone not found");

            _dbContext.Milestones.Remove(milestone);
            await _dbContext.SaveChangesAsync();
        }
    }
}

