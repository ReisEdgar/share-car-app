﻿using ShareCar.Db.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShareCar.Db.Repositories.Ride_Repository
{
   public interface IRideRepository
    {
        Ride GetRideById(int id);
        IEnumerable<Ride> GetRidesByDriver(string email);
        IEnumerable<Ride> GetRidesByDate(DateTime date);
        IEnumerable<Ride> GetRidesByDestination(int addressToId);
        IEnumerable<Ride> GetRidesByStartPoint(int addressFromId);
        IEnumerable<Passenger> GetPassengersByRideId(int rideId);
        bool UpdateRide(Ride ride);
        bool SetRideAsInactive(Ride ride);
        bool AddRide(Ride ride);
        IEnumerable<Ride> GetSimmilarRides(string driverEmail, int routeId, int rideId);
        IEnumerable<Ride> GetRidesByPassenger(Passenger passenger);
        IEnumerable<Ride> GetRidesByRoute(string routeGeometry);
    }
}
