using AutoMapper;
using Microsoft.AspNetCore.Identity;
using task_management_api.entities;
using task_management_api.exceptions;
using task_management_api.models.user;

namespace task_management_api.services
{

    public interface IUserService
    {
        public IEnumerable<UserDto> GetAllUsers();
        public UserDto GetById(int id);
        public int CreateUser(UserDto dto);
        public void EditUser(int id, UserDto dto);
        public void DeleteUser(int id);

        public System.Threading.Tasks.Task LogIn(UserLogInDto dto);
    }

    public class UserService : IUserService
    {
        private readonly TaskManagementDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _hasher;
        public UserService(TaskManagementDbContext dbContext,IMapper mapper, IPasswordHasher<User> hasher)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _hasher = hasher;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = _dbContext.Users.ToList();

            var usersDto = _mapper.Map<List<UserDto>>(users);

            return usersDto;
            
        }

        public UserDto GetById(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);

            if (user is null) throw new NotFoundException("User not Found");

            var userDto = _mapper.Map<UserDto>(user);


            return userDto;
        }

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

        public async System.Threading.Tasks.Task LogIn(UserLogInDto dto)
        {
            var user = _dbContext.Users.FirstOrDefault(user => user.Username == dto.Username);

            if (user is null) { throw new BadRequestException("User with that username do not exist"); }
            //var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);

            //if (result == PasswordVerificationResult.Failed) { throw new BadRequestException("Wrong password"); }
        }

        public void EditUser(int id, UserDto dto)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            
            if (user is null) throw new NotFoundException("User not Found");

            user = (User)ReflectionService.Reflect(dto,user);
         
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int id) 
        { 
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user is null) throw new NotFoundException("User not Found");



            _dbContext.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
