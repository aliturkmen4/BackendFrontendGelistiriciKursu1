using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true) //parametresiz olan success i gönderirsem sadece true yu gönderdim!
        {
        }

        public SuccessResult( string message) : base(true,message) //burada işlemin başarılı olduğunu söyleyerek sadece mesaj geçmek istedim!
        {
        }
    }
}
