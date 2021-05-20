using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.API.Exceptions.Users
{
    public class FieldValidate
    {
        public IEnumerable<string> Errors { get; set; }

        public FieldValidate(IEnumerable<string> errors)
        {
            this.Errors = errors;
        }
    }
}
