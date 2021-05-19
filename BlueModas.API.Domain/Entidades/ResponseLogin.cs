using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.API.Domain.Entidades
{
    public class ResponseLogin
    {
        public string Token { get; set; }
        public Users User { get; set; }
    }
}
