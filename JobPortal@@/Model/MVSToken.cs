using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal2.Model
{
    public class MVSToken
    {
        public const string Issuer = "MVS";
        public const string Audience = "ApiUser";
        public const string Key = "1234567890123456";


        public const string AuthScheme =
            "Identity.Applcation" + "," + JwtBearerDefaults.AuthenticationScheme;


    }
}
