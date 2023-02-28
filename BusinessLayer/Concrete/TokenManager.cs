using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TokenManager : ITokenService
    {
        private readonly IRepository<Token> _repository;

        public TokenManager(IRepository<Token> repository)
        {
            _repository = repository;
        }
        public Token CreateToken(Token data)
        {
            // Token oluşturma işlemleri
            var token = new Token
            {
                TokenValue = Guid.NewGuid().ToString(),
                ExpirationDate = DateTime.Now.AddDays(1)
            };

            // Token bilgilerini kaydetme işlemi
            _repository.Insert(token);

            return token;
        }

        public void RemoveToken(string tokenValue)
        {
            // Token silme işlemleri
            var token = _repository.Get(t => t.TokenValue == tokenValue);

            if (token != null)
            {
                _repository.Delete(token);
            }
        }

        public bool VerifyToken(string tokenValue)
        {
            // Token doğrulama işlemleri
            var token = _repository.Get(t => t.TokenValue == tokenValue && t.ExpirationDate > DateTime.Now);

            return token != null;
        }
    }
}
