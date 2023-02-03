using TaskAPI.Contracts.V1.Requests;

namespace TaskAPI.SwaggerExamples.Requests
{
    public class CreateAddressExample : IExternalScopeProvider<AddressCreateRequest>
    {
        public AddressCreateRequest GetCreateAddressExample() 
        {
            return new AddressCreateRequest
            {
                City = "Amsterdam",
                ZipCode = "1245GA",
                Country = "Netherlans",
                Street = "Plain1945",
                HouseNumber ="98a"
            };
        
        
        }
    }
}
