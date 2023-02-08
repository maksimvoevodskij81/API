﻿
using BackendData.DataAccess;
using BackendData.DomainModel;

namespace PieApp.Models
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            AppDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

            if (!context.Addresses.Any())
            {
                context.AddRange
                (
                    new Address { Country = "China", City = "Huangmei", Street = "700 Gale Lane", HouseNumber = "44", ZipCode = "71870" },
                    new Address { Country = "Indonesia", City = "Kliwon Cibingbin", Street = "98 Farragut Terrace", HouseNumber = "66", ZipCode = "88895" },
                    new Address { Country = "Thailand", City = "Tha Muang", Street = "8 Pearson Drive", HouseNumber = "99", ZipCode = "71110" },
                    new Address { Country = "Ukraine", City = "Komsomolsk", Street = "900 Buell Plaza", HouseNumber = "30", ZipCode = "7141KL" },
                    new Address { Country = "Indonesia", City = "Biyan", Street = "53 Swallow Center", HouseNumber = "51", ZipCode = "6754RE" },
                    new Address { Country = "Canada", City = "South River", Street = "2 Hansons Point", HouseNumber = "79", ZipCode = "P3Y" },
                    new Address { Country = "Indonesia", City = "Karanganyar", Street = "07 Caliangt Terrace", HouseNumber = "40", ZipCode = "5552OP" },
                    new Address { Country = "France", City = "Provins", Street = "52085 Swallow Alley", HouseNumber = "70", ZipCode = "7748CE" },
                    new Address { Country = "Poland", City = "Tylicz", Street = "62534 Bowman Pass", HouseNumber = "99", ZipCode = "333838" },
                    new Address { Country = "Canada", City = "Lloydminster", Street = "93135 Muir Hill", HouseNumber = "9", ZipCode = "S9V" }
                   
                );
            }

            context.SaveChanges();
        }

    }
}
