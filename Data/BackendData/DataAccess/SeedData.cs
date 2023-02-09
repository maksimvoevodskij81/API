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
                    new Address {Id = id++,  Country = "China", City = "Huangmei", Street = "700 Gale Lane", HouseNumber = "44", ZipCode = "71870" },
                    new Address {Id = id++, Country = "Indonesia", City = "Kliwon Cibingbin", Street = "98 Farragut Terrace", HouseNumber = "66", ZipCode = "88895" },
                    new Address {Id = id++, Country = "Thailand", City = "Tha Muang", Street = "8 Pearson Drive", HouseNumber = "99", ZipCode = "71110" },
                    new Address {Id = id++, Country = "Ukraine", City = "Komsomolsk", Street = "900 Buell Plaza", HouseNumber = "30", ZipCode = "7141KL" },
                    new Address {Id = id++, Country = "Indonesia", City = "Biyan", Street = "53 Swallow Center", HouseNumber = "51", ZipCode = "6754RE" },
                    new Address {Id = id++, Country = "Canada", City = "South River", Street = "2 Hansons Point", HouseNumber = "79", ZipCode = "P3Y" },
                    new Address {Id = id++, Country = "Indonesia", City = "Karanganyar", Street = "07 Caliangt Terrace", HouseNumber = "40", ZipCode = "5552OP" },
                    new Address {Id = id++, Country = "France", City = "Provins", Street = "52085 Swallow Alley", HouseNumber = "70", ZipCode = "7748CE" },
                    new Address {Id = id++, Country = "Poland", City = "Tylicz", Street = "62534 Bowman Pass", HouseNumber = "99", ZipCode = "333838" },
                    new Address {Id = id++, Country = "Canada", City = "Lloydminster", Street = "93135 Muir Hill", HouseNumber = "9", ZipCode = "S9V" }
            };

            return addresses;
        }
    }
}
