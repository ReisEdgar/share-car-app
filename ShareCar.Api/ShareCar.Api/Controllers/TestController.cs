﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShareCar.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Test")]
    public class TestController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Test( )
        {
            return await Task.Run(() => Ok("result"));
        }
    }
}