using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper  
    {
        //burada hash oluştruma işlemi yapıyorum
        public static void CreatePasswordHash(string password,
            out byte[] passwordHash, out byte[] passwordSalt)
        {
            //sha512
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; //algoritmanın o an oluşturduğu key değeridir
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        //kullanıcı sisteme tekrar girmeye çalışıyor bu password hashlenmiş
        //burada hash doğrulama işlemi yapıyorum
        public static bool VerifyPasswordHash(
            string password, byte[] passwordHash, byte[] passwordSalt) //password hashini doğrula
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }


    }
}

