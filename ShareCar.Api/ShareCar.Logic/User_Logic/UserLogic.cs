﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ShareCar.Db.Entities;
using ShareCar.Db.Repositories;
using ShareCar.Db.Repositories.User_Repository;
using ShareCar.Dto;
using ShareCar.Dto.Identity;
using ShareCar.Dto.Identity.Cognizant;
using ShareCar.Logic.ObjectMapping;
using ShareCar.Logic.Passenger_Logic;

namespace ShareCar.Logic.User_Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _userRepository;
        private readonly IPassengerLogic _passengerLogic;
        private readonly IMapper _mapper;

        public UserLogic(IUserRepository userRepository, IPassengerLogic passengerLogic, IMapper mapper)
        {
            _userRepository = userRepository;
            _passengerLogic = passengerLogic;
            _mapper = mapper;

        }

        public async Task<UserDto> GetUserAsync(ClaimsPrincipal principal)
        {
            var user = await _userRepository.GetLoggedInUser(principal);
            return user;
            
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers().ToList();

            var dtoUsers = new List<UserDto>();

            foreach(var user in users)
            {
                dtoUsers.Add(MapToDto(user));
            }

            return dtoUsers;
        }

        public async Task UpdateUserAsync(UserDto updatedUser, ClaimsPrincipal User)
        {
            var _userToUpdate = await _userRepository.GetLoggedInUser(User);
             
            if (_userToUpdate != null)
            {
                _userToUpdate.FirstName = updatedUser.FirstName;
                _userToUpdate.LastName = updatedUser.LastName;
                _userToUpdate.Phone = updatedUser.Phone;
                _userToUpdate.LicensePlate = updatedUser.LicensePlate;

                var _user = MapToEntity(_userToUpdate);
                await _userRepository.UpdateUserAsync(_user, User);
            }

        }

        public int CountPoints(string email)
        {
            return _passengerLogic.GetUsersPoints(email);
        }

        public Dictionary<UserDto, int> GetWinnerBoard()
        {
            Dictionary<UserDto, int> userWithPoints = new Dictionary<UserDto, int>();
            var users = _userRepository.GetAllUsers();
            int i = 0;
            foreach(var user in users)
            {
                int userPoints = CountPoints(user.Email);
                if(i<5)
                {
                    if (userPoints > 0)
                    {
                        userWithPoints.Add(MapToDto(user), userPoints);
                    }
                }
                else
                {
                    var lowestPoints = userWithPoints.Values.Min();
                    int count = userWithPoints.Where(x => x.Value == lowestPoints).Count();
                    if (lowestPoints < userPoints)
                    {
                        userWithPoints.Add(MapToDto(user), userPoints);
                        userWithPoints.Remove(userWithPoints.FirstOrDefault(x => x.Value == lowestPoints).Key);
                    }
                }
                i++;
            }
            userWithPoints = userWithPoints.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            return userWithPoints;
        }

        public UnauthorizedUserDto GetUnauthorizedUser(string email)
        {
           var user = _userRepository.GetUnauthorizedUser(email);
            if (user == null)
            {
                throw new ArgumentException("Unauthorized user doesn't exists");
            }
            return _mapper.Map<UnauthorizedUser, UnauthorizedUserDto>(user);
        }

        public Task CreateUser(UserDto userDto)
        {
            return _userRepository.CreateUser(MapToEntity(userDto));
        }

        public void CreateUnauthorizedUser(UnauthorizedUserDto userDto)
        {
            _userRepository.CreateUnauthorizedUser(_mapper.Map<UnauthorizedUserDto, UnauthorizedUser>(userDto));
        }

        // data parameter has either Facebbok email, either Google, but never both.
        public void SetUsersCognizantEmail(CognizantData data)
        {
            var user = _userRepository.GetUserByEmail(EmailType.COGNIZANT, data.CognizantEmail);
                bool facebookEmail = data.FacebookEmail != null;
                var loginEmail = facebookEmail ? data.FacebookEmail : data.GoogleEmail;

            if (user == null)
            {
                user = _userRepository.GetUserByEmail(EmailType.LOGIN, loginEmail);

                if (facebookEmail)
                {
                    user.FacebookEmail = loginEmail;
                }
                else
                {
                    user.GoogleEmail = loginEmail;
                }
                user.CognizantEmail = data.CognizantEmail;
            }
            else 
            {

                var tempUser = _userRepository.GetUserByEmail(EmailType.LOGIN, loginEmail); // acc which is created when user logs in with second
                // email for the first time. After verification, it is unused.
                if (tempUser.CognizantEmail == null)
                {
                    tempUser.GoogleEmail = null;
                    tempUser.FacebookEmail = null;
                    _userRepository.UpdateUser(tempUser);
                }

                if (!user.FacebookVerified && data.FacebookEmail != null)
                {
                    user.FacebookEmail = data.FacebookEmail;

                }
                else if (!user.GoogleVerified && data.GoogleEmail != null)
                {
                    user.GoogleEmail = data.GoogleEmail;

                }
                user.CognizantEmail = data.CognizantEmail;

            }
             _userRepository.UpdateUser(user);

        }

        public void VerifyUser(bool faceBookVerified, string loginEmail)
        {
            var user = _userRepository.GetUserByEmail(EmailType.LOGIN, loginEmail);

            if (faceBookVerified)
            {
                user.FacebookVerified = true;
            }
            else
            {
                user.GoogleVerified = true;
            }
            
             _userRepository.UpdateUser(user);
        }

        public UserDto GetUserByEmail(EmailType type, string email)
        {
            User user = _userRepository.GetUserByEmail(type, email);

            if (user == null)
            {
                return null;
            }

            return MapToDto(user);
        }

        public bool DoesUserExist(EmailType type, string cognizantEmail)
        {
            if (cognizantEmail == null)
            {
                return false;
            }

            var cognizantUser = _userRepository.GetUserByEmail(EmailType.COGNIZANT, cognizantEmail);

            if(cognizantUser == null)
            {
                return false;
            }

            else
            {
                if(type == EmailType.FACEBOOK && cognizantUser.FacebookVerified)
                {
                    return true;
                }
                if (type == EmailType.GOOGLE && cognizantUser.GoogleVerified)
                {
                    return true;
                }
            }
            return false;

        }

        private UserDto MapToDto(User user)
        {
            return new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                FacebookEmail = user.FacebookEmail,
                FacebookVerified = user.FacebookVerified,
                GoogleEmail = user.GoogleEmail,
                GoogleVerified = user.GoogleVerified,
                CognizantEmail = user.CognizantEmail,
                Email = user.Email,
                LicensePlate = user.LicensePlate,
                Phone = user.Phone
            };
        }

        private User MapToEntity(UserDto user)
        {
            return new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                FacebookEmail = user.FacebookEmail,
                FacebookVerified = user.FacebookVerified,
                GoogleEmail = user.GoogleEmail,
                GoogleVerified = user.GoogleVerified,
                CognizantEmail = user.CognizantEmail,
                Email = user.Email,
                LicensePlate = user.LicensePlate,
                Phone = user.Phone
            };
        }
    }
}
