using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedServices.IService
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
