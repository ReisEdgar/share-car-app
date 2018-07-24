﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShareCar.Db.Entities;
using ShareCar.Dto.Identity;
using ShareCar.Logic.Identity;

namespace ShareCar.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Ride")]
    public class RideController : Controller
    {
        private readonly IRideLogic _rideLogic;

        public RideController(IRideLogic rideLogic)
        {
            _rideLogic = rideLogic;
        }

        [HttpGet("{rideId}")]
        public IActionResult GetRideById(int rideId)
        {

            RideDto ride = _rideLogic.FindRideById(rideId);

            if (ride == null)
            {
                return NotFound();
            }
            return Ok(ride);
        }



        [HttpGet("{driverEmail}")]
        public void GetRidesByDriver(string driverEmail)
        {

            IEnumerable<RideDto> Rides = _rideLogic.FindRidesByDriver(driverEmail);

            SendResponse(Rides);


        }

        [HttpGet("{rideDate}")]
        public void GetRidesByDate(DateTime rideDate)
        {

            IEnumerable<RideDto> Rides = _rideLogic.FindRidesByDate(rideDate);

            SendResponse(Rides);

        }

        [HttpGet("addressFrom={addressFrom}")]
        public void GetRidesByStartPoint(AddressDto addressFrom)
        {

            IEnumerable<RideDto> Rides = _rideLogic.FindRidesByStartPoint(addressFrom);

            SendResponse(Rides);

        }

        [HttpGet("addressTo={addressTo}")]
        public void GetRidesByDestination(AddressDto addressTo)
        {

            IEnumerable<RideDto> Rides = _rideLogic.FindRidesByDestination(addressTo);

            SendResponse(Rides);

        }
        
        // Any object update. If user doesn't change property, it should be delivered unchanged
        [HttpPut]
        public IActionResult Put([FromBody] RideDto ride)
        {
            if (ride == null)
            {
                return BadRequest("Invalid parameter");
            }

            bool result = _rideLogic.UpdateRide(ride);

            if(result)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Operation failed");
            }

        }

        // Any object update, if user doesn't change properti, it should be delivered unchanged
        [HttpPost]
        public IActionResult Post([FromBody] RideDto ride)
        {
            if (ride == null)
            {
                return BadRequest("Invalid parameter");
            }

            bool result = _rideLogic.AddRide(ride);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Operation failed");
            }

        }

        private IActionResult SendResponse(IEnumerable<RideDto> ride)
        {

            if (ride == null)
            {
                return NotFound();
            }
            return Ok(ride);
        }

    }


}