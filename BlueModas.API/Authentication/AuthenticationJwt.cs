using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.API.Authentication
{
    public class AuthenticationJwt
    {
        public static byte[] InitConfigureJwtAuthetication(string jwtKeyConfiguratio)
        {
            return Encoding.ASCII.GetBytes(jwtKeyConfiguratio);
        }
    }
}
