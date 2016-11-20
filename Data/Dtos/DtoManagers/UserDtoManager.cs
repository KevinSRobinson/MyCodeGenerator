



		using System;
using System.Collections.Generic;
using System.Linq;
using Api;
using Data.Models;
using Data;
using Dtos;
namespace Dto.DtoRepos
{
    public interface IUserDtoRepo
    {
        void MapUser(ref User UserDto, ref UserDto userDto);
        IEnumerable<UserDto> GetAllUsers();
        IEnumerable<UserDto> GetUserUsers(Guid id);
        UserDto AddUser(UserDto userDto, Guid userId);
        void ModifyUser(UserDto userDto);
        UserDto GetUser(int id);
    }

    public class UserDtoRepo : IUserDtoRepo
    {
        private readonly IUnitOfWork _unitOfWork;


        public UserDtoRepo()
        {
            _unitOfWork = new UnitOfWork();
        }

        public UserDtoRepo(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void MapUser(ref User user, ref UserDto userDto)
        {
           	user.Id = userDto.Id;
user.UserId = userDto.UserId;
user.OldId = userDto.OldId;
user.OldOrgId = userDto.OldOrgId;
user.Username = userDto.Username;
user.Password = userDto.Password;
user.PasswordText = userDto.PasswordText;
user.DisplayName = userDto.DisplayName;
user.Email = userDto.Email;
user.Organisation = userDto.Organisation;
user.FirstName = userDto.FirstName;
user.Surname = userDto.Surname;
user.Hours = userDto.Hours;
user.Mobile = userDto.Mobile;
user.UserType = userDto.UserType;
user.Role = userDto.Role;
   
        }

        public void MapUser(ref UserDto user, ref User userDto)
        {
          	user.Id = userDto.Id;
user.UserId = userDto.UserId;
user.OldId = userDto.OldId;
user.OldOrgId = userDto.OldOrgId;
user.Username = userDto.Username;
user.Password = userDto.Password;
user.PasswordText = userDto.PasswordText;
user.DisplayName = userDto.DisplayName;
user.Email = userDto.Email;
user.Organisation = userDto.Organisation;
user.FirstName = userDto.FirstName;
user.Surname = userDto.Surname;
user.Hours = userDto.Hours;
user.Mobile = userDto.Mobile;
user.UserType = userDto.UserType;
user.Role = userDto.Role;
   
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            try
            {
                var  users = _unitOfWork.Users.GetAll();
               var results =  users.Select(x => new UserDto()
                {
					Id = x.Id,
UserId = x.UserId,
OldId = x.OldId,
OldOrgId = x.OldOrgId,
Username = x.Username,
Password = x.Password,
PasswordText = x.PasswordText,
DisplayName = x.DisplayName,
Email = x.Email,
Organisation = x.Organisation,
FirstName = x.FirstName,
Surname = x.Surname,
Hours = x.Hours,
Mobile = x.Mobile,
UserType = x.UserType,
Role = x.Role,
                });
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Build AddUser Dto", ex);
            }
        }

        public IEnumerable<UserDto> GetUserUsers(Guid id)
        {
            try
            {
                var Users = _unitOfWork.Users.GetByUserId(id);
                var results = Users.Select(x => new UserDto()
                {
					Id = x.Id,
UserId = x.UserId,
OldId = x.OldId,
OldOrgId = x.OldOrgId,
Username = x.Username,
Password = x.Password,
PasswordText = x.PasswordText,
DisplayName = x.DisplayName,
Email = x.Email,
Organisation = x.Organisation,
FirstName = x.FirstName,
Surname = x.Surname,
Hours = x.Hours,
Mobile = x.Mobile,
UserType = x.UserType,
Role = x.Role,
                });

                return results;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Build AddUser Dto", ex);
            }
        }

        public UserDto AddUser(UserDto userDto, Guid userId)
        {
            try
            {
             var user = new User ();

				MapUser(ref  user , ref userDto);
				 

                _unitOfWork.Users.Add(user);
                _unitOfWork.Save();

                userDto.Id = user.Id;
                return userDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Build AddUser Dto", ex);
            }
        }

        public void ModifyUser(UserDto userDto)
        {
            try
            {
                var user= _unitOfWork.Users.GetById(userDto.Id);
                 MapUser(ref user, ref userDto);
				 
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Build Modify User Dto", ex);
            }
        }

        public UserDto GetUser(int id)
        {
            try
            {
                var user = _unitOfWork.Users.GetById(id);
               var userDto = new UserDto();
                MapUser(ref userDto, ref user);

                return userDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Build Modify User Dto", ex);
            }
        }
    }
}
		
		
		