﻿using System;
using System.Collections.Generic;
using System.Text;
using ShareCar.Db.Entities;
using ShareCar.Dto.Identity;

namespace ShareCar.Logic.Identity
{
    public class PersonLogic : IPersonLogic
    {

        IPersonRepository _personRepository;

        public PersonLogic(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void AddPerson(Person person)
        {
            _personRepository.AddPerson(person);
        }

        public PersonDto GetPersonByEmail(string email)
        {
            Person person = _personRepository.GetPersonByEmail(email);
            return new PersonDto
            {
                Email = person.Email,
                FirstName = person.FirstName,
                LastName = person.LastName

            };
        }
    }
}