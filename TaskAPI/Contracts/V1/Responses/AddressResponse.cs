using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection.Emit;

namespace TaskAPI.Contracts.V1.Responses
{
    public class AddressResponse
    {
        public int? Id { get; private set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? Street { get; set; }
        public int? HouseNumber { get; set; }
        public AddressResponse()
        {

        }
        public AddressResponse(int addressId, string country, string city, string street, int houseNumber, string zipCode)
        {
            Id = addressId;
            City = city;
            ZipCode = zipCode;
            Country = country;
            Street = street;
            HouseNumber = houseNumber;
        }
    }
}
