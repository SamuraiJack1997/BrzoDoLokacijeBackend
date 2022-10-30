using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProjekatAPI.TokenAuthentication
{
    public class Token
    {
        public string Value { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
