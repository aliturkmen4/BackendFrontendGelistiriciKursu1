using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class TokenOptions //apimizde setting içinde bilgi olarak tutacağız!
    {
        public string Audience { get; set; }

        public string Issuer { get; set; }

        public int AccessTokenExpiration { get; set; } //dakika cinsinden yazdığım için int!

        public string SecurityKey { get; set; }
    }
}
