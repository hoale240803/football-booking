using FootballBooking.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballBooking.Test.SeedData
{
    public static class StadiumData
    {
        public static string Name = "StadiumName";
        public static string OwnerName = "OwnerName";

        public static QueryParams QueryParams = new QueryParams
        {
            PageNumber = 1,
            PageSize = 10,
        };



        public static StadiumParams StadiumParams = new StadiumParams
        {
            PageNumber = 1,
            PageSize = 10,
        };
    }
}
