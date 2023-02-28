using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ITokenService
    {
        Token CreateToken(Token data);
        bool VerifyToken(string tokenValue);
        void RemoveToken(string tokenValue);
    }
}
