using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.API.Exceptions.Login
{
    public class LoginError
    {
        public IEnumerable<string> Errors { get; set; }

        public LoginError(IEnumerable<string> errors)
        {
            this.Errors = errors;
        }
    }
}
