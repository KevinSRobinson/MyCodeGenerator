
using Data.Models;
using Data.Repositories;
using Dtos;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace Api
{
    [EnableCors("*", "*", "*")]
    public class UsersApiController : ApiBase
    {
        private readonly UnitOfWork _unitOfWork;

        #region "constructors"
        public UsersApiController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public UsersApiController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        private void MapUser(ref User user, ref UserDto userDto)
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


        [Route("api/GetAllUsers")]
        public IHttpActionResult GetAllUsers()
        {
            try
            {
                var users = _unitOfWork.Users.GetAll();
                var results = users.Select(x => new UserDto()
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

                return Ok(results);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, this);
            }

        }

        [HttpPost]
        [Route("api/AddUser")]
        public IHttpActionResult AddUser(UserDto userDto)
        {
            try
            {
                var user = new User();

                MapUser(ref user, ref userDto);


                _unitOfWork.Users.Add(user);
                _unitOfWork.Save();

                userDto.Id = user.Id;
                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, this);
            }
        }

        [HttpPost]
        [Route("api/ModifyUser")]
        public IHttpActionResult ModifyUser(UserDto userDto)
        {
            try
            {
                var user = _unitOfWork.Users.GetById(userDto.Id);
                MapUser(ref user, ref userDto);

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

                _unitOfWork.Save();

                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, this);
            }
        }


        [Route("api/GetUsers/{id}")]
        public IHttpActionResult GetUser(int id)
        {
            var user = _unitOfWork.Users.GetById(id);

            var userDto = new UserDto()
            {

                Id = user.Id,
                UserId = user.UserId,
                OldId = user.OldId,
                OldOrgId = user.OldOrgId,
                Username = user.Username,
                Password = user.Password,
                PasswordText = user.PasswordText,
                DisplayName = user.DisplayName,
                Email = user.Email,
                Organisation = user.Organisation,
                FirstName = user.FirstName,
                Surname = user.Surname,
                Hours = user.Hours,
                Mobile = user.Mobile,
                UserType = user.UserType,
                Role = user.Role,
            };

            return Ok(userDto);
        }
    }
}


