using System.ComponentModel.DataAnnotations;

namespace BackendData.DomainModel
{
    public class Address : BaseEntity
    {
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; } 
        public string? Street { get; set; }
        public int? HouseNumber { get; set; }
    }
}