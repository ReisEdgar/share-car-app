﻿using ShareCar.Db.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ShareCar.Db.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _databaseContext;

        public AddressRepository(ApplicationDbContext context)
        {
            _databaseContext = context;
        }
        public bool AddNewAddress(Address address)
        {
            try
            {
                _databaseContext.Addresses.Add(address);
                _databaseContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
                
        }

        // Address consists of street, house number and city or geo coordinates
        public int GetAddressId(Address address)
        {
            if (address.City != null && address.Street != null && address.Number != null)
            {
                try
                {
                    return _databaseContext.Addresses.Single(x => (x.City == address.City && x.Street == address.Street && x.Number == address.Number)).AddressId;
                }
                catch
                {
                    return -1;
                }
            }


              else  if (address.Longtitude != 0 && address.Latitude != 0)
                {
                    try
                    {

                        return _databaseContext.Addresses.Single(x => x.Longtitude == address.Longtitude && x.Latitude == address.Latitude).AddressId;

                    }
                    catch
                    {
                        return -1; // Address doesnt exist

                    }
                

            }
            return - 1;
            
        }

        public Address FindAddressById(int id)
        {
            try
            {
           return _databaseContext.Addresses.SingleOrDefault(x => x.AddressId == id);

            }
            catch
            {
                return null;
            }
        }
    }
}
