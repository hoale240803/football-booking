﻿using System.ComponentModel.DataAnnotations;

namespace FootballBooking.Entities.DTOs
{
    public class AddressDTO
    {

        public string Street { get; set; }


        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}