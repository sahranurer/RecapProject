using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class SuccessDataResult<T> :DataResult<T>
    {
        //buradaki amacımız kullanım drumuna göre oluşmaktadır.

        //burada sadece data ve mesaj vermek için kullanırız
        public SuccessDataResult(T data,string message) : base(data, true, message)
        {

        }
        //burada sadece data  vermek için kullanırız
        public SuccessDataResult(T data):base(data,true)
        {

        }
        //burada sadece  mesaj vermek için kullanırız
        public SuccessDataResult(string message) : base(default,true,message)
        {

        }
        //burada hiçbirşey verme  kullanırız
        public SuccessDataResult() : base(default, true)
        {

        }


    }
}
