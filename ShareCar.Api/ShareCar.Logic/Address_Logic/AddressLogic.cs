using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
﻿using AutoMapper;
using ShareCar.Db.Repositories;
using ShareCar.Db.Entities;
using ShareCar.Dto;

namespace ShareCar.Logic.Address_Logic
{
    class AddressLogic : IAddressLogic
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        public AddressLogic(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        public bool AddNewAddress(AddressDto address)
        {
            Address entityAddress = new Address
            {
                City = address.City,
                Street = address.Street,
                Number = address.Number,
                Longtitude = address.Longtitude,
                Latitude = address.Latitude
            };
            
              return _addressRepository.AddNewAddress(entityAddress);

        }

        public int GetAddressId(AddressDto address)
        {

            Address entityAddress = _mapper.Map<AddressDto, Address>(address);


            int id = _addressRepository.GetAddressId(entityAddress);

            if (id == -1)
            {
                bool added = _addressRepository.AddNewAddress(entityAddress);

                if (added)
                {
                    return _addressRepository.GetAddressId(entityAddress);
                }
            }

            return id;

        }

        public AddressDto GetAddressById(int id)
        {
            
         Address address = _addressRepository.GetAddressById(id);

            return _mapper.Map<Address, AddressDto>(address);
        }


    }
}
