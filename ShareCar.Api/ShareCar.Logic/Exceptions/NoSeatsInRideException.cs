﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShareCar.Logic.Exceptions
{
    public class NoSeatsInRideException : Exception
    {
        public NoSeatsInRideException(string message)
    : base(message)
        {

        }
    }
}
