using System.Collections.Generic;

namespace EasyBus.Models
{
    public class AuthenticationResponse
    {
        public bool Successful { get; set; }

        public IEnumerable<string> Errors { get; set; }
        public string Token { get; set; }
    }
}