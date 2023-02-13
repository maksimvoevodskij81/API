using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendData.DomainModel
{
    public class AuthenticationResult
    {
        public string Token { get; set; } = string.Empty;
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }

    }
}
