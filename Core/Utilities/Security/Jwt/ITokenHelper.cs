using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        //api siteminde kullanıcı adı şifresi girildi
        //burada eğer doğruysa ilgili veritabanına gidicek ve bu kullanıcının
        //claimlerini bulucak,jwt üreticek
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
