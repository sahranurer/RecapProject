using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
   public class SigningCredentialHelper
    {
        //bizim için json web servislerini,json web tokenlarının oluşturulabilmesi için
        //
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            //hangi anahtarı kullanıcaksın hangi algoritmayı kullanacağını haber veriyorum apiye
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
        }
    }
}
