﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using ShareCar.Db.Repositories;
using ShareCar.Dto.Identity;
using ShareCar.Logic.Request_Logic;
=======
using ShareCar.Dto.Identity;
>>>>>>> dev

namespace ShareCar.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Request")]
    public class RequestController : Controller
    {
<<<<<<< HEAD
        private readonly IRequestLogic _requestLogic;
        private readonly IUserRepository _userRepository;

             public RequestController(IRequestLogic requestLogic, IUserRepository userRepository)
            {
               _requestLogic = requestLogic;
            _userRepository = userRepository;
           }

        [HttpGet("{requestId}")]
        public IActionResult GetRequestById(int requestId)
        {
=======
        [HttpGet]
        public void GetRequestById()
        {/*
            RequestDto request = _requestLogic.FindRequestByRequestId(requestId);
            if (request == null)
            {
                return NotFound("Operation failed");
            }
            return Ok(request);*/
        }
        [HttpPut]
        public IActionResult Post([FromBody]  RideDto ride)
        {/*
>>>>>>> dev
            RequestDto request = _requestLogic.FindRequestByRequestId(requestId);
            if (request == null)
            {
                return NotFound("Operation failed");
<<<<<<< HEAD
            }
            return Ok(request);
        }
        [HttpGet("/passengerEmail")]
        public async Task<IActionResult> GetRequestByPassengerEmailAsync()
        {

            var userDto = await _userRepository.GetLoggedInUser(User);

            IEnumerable<RequestDto> request = _requestLogic.FindRequestsByPassengerEmail(userDto.Email);
            if (request != null)
            {
                return Ok(request);
            }
            else
            {
                return BadRequest("Operation failed");
            }
        }
        [HttpGet("/driverEmail")]
        public async Task<IActionResult> GetRequestsByPassengerEmailAsync()
        {
            var userDto = await _userRepository.GetLoggedInUser(User);

            IEnumerable<RequestDto> request = _requestLogic.FindRequestsByDriverEmail(userDto.Email);
            if (request != null)
            {
                return Ok(request);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("{addressId}")]
        public void GetRequestsByPickUpPoint(AddressDto addressId)
        {

            IEnumerable<RequestDto> request = _requestLogic.FindRidesByPickUpPoint(addressId);

            if (request != null)
            {
                Ok(request);
            }
            else
            {
                BadRequest("Operation failed");
            }
        }
        [HttpGet("{rideId}")]
        public IActionResult GetRequestByRide(int rideId)
        {
            IEnumerable<RequestDto> request = _requestLogic.FindRequestByRideId(rideId);
            if (request != null)
            {
                return Ok(request);
            }
            else
            {
                return BadRequest("Operation failed");
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] RequestDto request)
        {
            if (request == null)
            {
                return BadRequest("Invalid input");
            }

            bool result = _requestLogic.AddRequest(request);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Operation failed");
            }
        }

        // Should be called only by driver
        [HttpPut]
        public IActionResult Put([FromBody] string request)
        {
            if (request == null)
            {
                return BadRequest("Invalid parameter");
            }
            //  bool result = _requestLogic.UpdateRequest(request);

            //   if (result)
            {
                return Ok();
            }
            //    else
            {
                //      return BadRequest("Operation failed");
            }
=======
            }*/
            return Ok();
>>>>>>> dev
        }
    }

}