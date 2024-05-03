﻿using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    }

    public class UserService : IUserService
    {
        private readonly TaskManagementDbContext _dbContext;
        private readonly IMapper _mapper;
        public UserService(TaskManagementDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = _dbContext.users.ToList();

            var usersDto = _mapper.Map<List<UserDto>>(users);

            return usersDto;
            
        }

        public UserDto GetById(int id)
        {
            var user = _dbContext.users.FirstOrDefault(x => x.Id == id);

            if (user is null) throw new NotFoundException("User not Found");

            var userDto = _mapper.Map<UserDto>(user);


            return userDto;
        }

        public int CreateUser(UserDto dto)
        {
            var user = _mapper.Map<User>(dto);

            _dbContext.users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }

        public void EditUser(int id, UserDto dto)
        {
            var user = _dbContext.users.FirstOrDefault(x => x.Id == id);
            
            if (user is null) throw new NotFoundException("User not Found");

            user = (User)ReflectionService.Reflect(dto,user);
         
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int id) 
        { 
            var user = _dbContext.users.FirstOrDefault(u => u.Id == id);
            if (user is null) throw new NotFoundException("User not Found");



            _dbContext.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
