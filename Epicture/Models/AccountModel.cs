using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicture.Models
{
    public class AccountModel
    {
        public AccountModel(string account, string token, string expires, string refresh, string name)
        {
            this.AccountId = account;
            this.Token = token;
            this.Expires = expires;
            this.Refresh = refresh;
            this.Name = name;
        }

        public string AccountId { get; set; }

        public string Token { get; set; }

        public string Expires { get; set; }

        public string Refresh { get; set; }

        public string Name { get; set; }
    }
}
