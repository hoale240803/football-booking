﻿namespace FootballBooking.Entities.DTOs
{
    public class StadiumParams : QueryParams
    {
        public AddressDTO Address { get; set; }

        public string Name { get; set; }
    }
}