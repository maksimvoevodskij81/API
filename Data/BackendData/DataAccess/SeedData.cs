using BackendData.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendData.DataAccess
{
    public static class SeedData
    {
        public static List<Address> Addresses()
        {
            int id = 1;

            var addresses = new List<Address>()
            {
                new Address
                {
                    Id = id++,
                    Country = "Netherlands",
                    City = "IJmuiden",
                    Street = "Plain1945",
                    ZipCode = "1971GL",
                    HouseNumber = "45"

                },
                new Address
                {
                    Id = id++,
                    Country = "Netherlands",
                    City = "Haarlem",
                    ZipCode = "2031BJ",
                    Street = "Hendrik Figeeweg",
                    HouseNumber = "78"
                }
            };

            return addresses;
        }
    }
}
