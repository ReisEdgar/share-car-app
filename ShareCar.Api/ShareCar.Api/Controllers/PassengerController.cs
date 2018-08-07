﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShareCar.Dto;

namespace ShareCar.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Passenger")]
    public class PassengerController : Controller
    {
        [HttpPost]
        public IActionResult RideCompleted([FromBody] PassengerDto passenger)
        {

            return Ok();
        }
    }
}