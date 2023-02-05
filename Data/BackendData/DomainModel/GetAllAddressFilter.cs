using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendData.DomainModel
{
    public class GetAllAddressFilter : IEnumerable<string>
    {
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public IEnumerator<string> GetEnumerator()
        {
            yield return City;
            yield return ZipCode;
            yield return Country;
            yield return Street;
            yield return HouseNumber;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();

        }
    }
    
}
