﻿using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using task_management_api.entities;
using task_management_api.models;

namespace task_management_api.services
{

    public interface IUserService
    {
        public IEnumerable<User> GetAllUsers();
        public User GetById(int id);
        public int CreateUser(UserDto dto);
        public bool EditUser(int id, UserDto dto);
        public bool DeleteUser(int id); 
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

        public IEnumerable<User> GetAllUsers()
        {
            var users = _dbContext.users.ToList();

            return users;
            
        }

        public User GetById(int id)
        {
            var user = _dbContext.users.FirstOrDefault(x => x.Id == id);

            return user;
        }

        public int CreateUser(UserDto dto)
        {
            var user = _mapper.Map<User>(dto);

            _dbContext.users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }

        public bool EditUser(int id, UserDto dto)
        {
            var user = _dbContext.users.FirstOrDefault(x => x.Id == id);
            
            if (user is null)
            {
                return false;
            }

            var userProperties = typeof(User).GetProperties();
            var userDtoProperties = typeof(UserDto).GetProperties();

            foreach (var dtoProperty in userDtoProperties)
            {
                var userProperty = userProperties.FirstOrDefault(p => p.Name == dtoProperty.Name);

                var userValue = userProperty.GetValue(user);
                var dtoValue = dtoProperty.GetValue(dto);

                if(userValue != dtoProperty)
                {
                    userProperty.SetValue(user,dtoValue);
                }

            }
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteUser(int id) 
        { 
            var user = _dbContext.users.FirstOrDefault(u => u.Id == id);
            if (user is null)
            {
                return false;
            }

            _dbContext.Remove(user);
            _dbContext.SaveChanges();
            return true;
        }
    }
}