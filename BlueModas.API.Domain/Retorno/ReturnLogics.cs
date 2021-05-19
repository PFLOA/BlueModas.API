using BlueModas.API.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.API.Domain.Retorno
{
    public class ReturnLogics
    {
        public static bool UserNotFoundEnum(RetornosEnum retornosEnum)
        {
            if (retornosEnum == RetornosEnum.UserNotFound)
            {
                return true;
            }

            return false;
        }
        public static bool UserUpdatedEnum(RetornosEnum retornosEnum)
        {
            if (retornosEnum == RetornosEnum.UserUpdated)
            {
                return true;
            }

            return false;
        }
        public static bool UserDifferentIdEnum(RetornosEnum retornosEnum)
        {
            if (retornosEnum == RetornosEnum.UserDifferentId)
            {
                return true;
            }

            return false;
        }
        public static bool ParameterNullEnum(RetornosEnum retornosEnum)
        {
            if (retornosEnum == RetornosEnum.ParameterNull)
            {
                return true;
            }

            return false;
        }
    }
}
