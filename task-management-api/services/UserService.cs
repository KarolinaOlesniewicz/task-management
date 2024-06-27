using AutoMapper;
using Microsoft.AspNetCore.Identity;
using task_management_api.entities;
using task_management_api.exceptions;
using task_management_api.models.user;

namespace task_management_api.services
{
    /// <summary>
    /// Defines an interface for user management services.
    /// This interface specifies methods for user operations like retrieval, creation, modification, and deletion.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Retrieves a collection of all user data transfer objects (DTOs).
        /// </summary>
        /// <returns>An IEnumerable of UserDto objects representing all users.</returns>
        IEnumerable<UserDto> GetAllUsers();

        /// <summary>
        /// Retrieves a specific user data transfer object (DTO) by its identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user to retrieve.</param>
        /// <returns>A UserDto object representing the user with the specified ID, or null if not found.</returns>
        UserDto GetById(int id);

        /// <summary>
        /// Creates a new user in the system.
        /// </summary>
        /// <param name="dto">The UserDto object containing the data for the new user.</param>
        /// <returns>The ID of the newly created user.</returns>
        int CreateUser(UserDto dto);

        /// <summary>
        /// Edits an existing user's data.
        /// </summary>
        /// <param name="id">The unique identifier of the user to edit.</param>
        /// <param name="dto">The UserDto object containing the updated data for the user.</param>
        public void EditUser(int id, UserDto dto);

        /// <summary>
        /// Deletes a user from the system.
        /// </summary>
        /// <param name="id">The unique identifier of the user to delete.</param>
        public void DeleteUser(int id);

        /// <summary>
        /// Attempts to log a user into the system using the provided credentials.
        /// This method is asynchronous.
        /// </summary>
        /// <param name="dto">The UserLogInDto object containing the login credentials (username and password).</param>
        /// <returns>A task object that represents the asynchronous login operation. Upon successful login, no explicit value is returned from the task.</returns>
        /// <exception cref="BadRequestException">Thrown if the username is not found or the password is incorrect.</exception>
        public System.Threading.Tasks.Task LogIn(UserLogInDto dto);
    }

    /// <summary>
    /// Service implementation for managing users.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly TaskManagementDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _hasher;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="dbContext">The database context for task management.</param>
        /// <param name="mapper">The mapper for object-object mapping.</param>
        /// <param name="hasher">The password hasher for hashing user passwords.</param>
        public UserService(TaskManagementDbContext dbContext,IMapper mapper, IPasswordHasher<User> hasher)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _hasher = hasher;
        }

        /// <inheritdoc />
        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = _dbContext.Users.ToList();

            var usersDto = _mapper.Map<List<UserDto>>(users);

            return usersDto;
            
        }

        /// <inheritdoc />
        public UserDto GetById(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);

            if (user is null) throw new NotFoundException("User not Found");

            var userDto = _mapper.Map<UserDto>(user);


            return userDto;
        }

        /// <inheritdoc />
        public int CreateUser(UserDto dto)
        {
            var user = _mapper.Map<User>(dto);

            var usernamecheck = _dbContext.Users.FirstOrDefault(Check => Check.Username == dto.Username);
            if(usernamecheck is not null)
            {
                throw new BadRequestException("User with that username already exist");
            }

            var emailCheck = _dbContext.Users.FirstOrDefault(Check => Check.Email == dto.Email);
            if (emailCheck is not null)
            {
                throw new BadRequestException("User with that email already exist");

            }

            user.PasswordHash = _hasher.HashPassword(user,user.PasswordHash);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }

        /// <inheritdoc />
        public async System.Threading.Tasks.Task LogIn(UserLogInDto dto)
        {
            var user = _dbContext.Users.FirstOrDefault(user => user.Username == dto.Username);

            if (user is null) { throw new BadRequestException("User with that username do not exist"); }

            var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            if (result == PasswordVerificationResult.Failed) { throw new BadRequestException("Wrong password"); }
        }

        /// <inheritdoc />
        public void EditUser(int id, UserDto dto)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            
            if (user is null) throw new NotFoundException("User not Found");

            user = (User)ReflectionService.Reflect(dto,user);
         
            _dbContext.SaveChanges();
        }

        /// <inheritdoc />
        public void DeleteUser(int id) 
        { 
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user is null) throw new NotFoundException("User not Found");



            _dbContext.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
