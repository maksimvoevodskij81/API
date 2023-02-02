namespace BackendData.DomainModel
{
    public class Address
    {
        public int AddressId { get; private set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
    }
}