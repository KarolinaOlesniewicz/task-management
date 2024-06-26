using AutoMapper;
using Microsoft.EntityFrameworkCore;
using task_management_api.entities;
using task_management_api.exceptions;
using task_management_api.models.milestone;
using Task = System.Threading.Tasks.Task;

namespace task_management_api.services
{
    public interface IMilestoneService
    {
        Task<IEnumerable<MilestoneDto>> GetAllMilestonesForBoard(int userId, int workspaceId, int boardId);
        Task<MilestoneDto> GetMilestoneById(int milestoneId);
        Task AddMilestoneForBoard(CreateMilestoneDto dto, int boardId);
        Task UpdateMilestone(int milestoneId, CreateMilestoneDto dto);
        Task DeleteMilestone(int milestoneId);
    }

    public class MilestoneService : IMilestoneService
    {
        private readonly TaskManagementDbContext _dbContext;
        private readonly IMapper _mapper;

        public MilestoneService(TaskManagementDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

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

        public async Task<MilestoneDto> GetMilestoneById(int milestoneId)
        {
            var milestone = await _dbContext.Milestones.FindAsync(milestoneId);

            if (milestone == null)
                throw new NotFoundException("Milestone not found");

            var milestoneDto = _mapper.Map<MilestoneDto>(milestone);
            return milestoneDto;
        }

        public async Task AddMilestoneForBoard(CreateMilestoneDto dto, int boardId)
        {
            var milestone = _mapper.Map<Milestone>(dto);
            milestone.BoardId = boardId;

            _dbContext.Milestones.Add(milestone);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateMilestone(int milestoneId, CreateMilestoneDto dto)
        {
            var milestone = await _dbContext.Milestones.FindAsync(milestoneId);

            if (milestone == null)
                throw new NotFoundException("Milestone not found");

            _mapper.Map(dto, milestone);

            await _dbContext.SaveChangesAsync();
        }

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

