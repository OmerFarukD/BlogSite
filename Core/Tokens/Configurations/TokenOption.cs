using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tokens.Configurations
{
    public class TokenOption
    {
        public string Issuer { get; set; }
        public List<string> Audience { get; set; }
        public int AccessTokenExpiration { get; set; }

        public string SecurityKey { get; set; }
    }
}
