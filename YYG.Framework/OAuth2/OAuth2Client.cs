using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYG.Framework.OAuth2
{
   public class OAuth2Client
    {
        public string Id { get; set; }

        public string Secret { get; set; }

        public string RedirectUrl { get; set; }
    }

    public class OAuth2ClientRepository
    {
        public static List<OAuth2Client> Clients = new List<OAuth2Client>() {
            new OAuth2Client{
                 Id = "test1",
                 RedirectUrl = "http://localhost:59273/",
                 Secret = "123456789"
            },
            new OAuth2Client{
                 Id = "test2",
                 RedirectUrl = "http://XXX.XXX.XXX/",
                 Secret = "987654321"
            }
        };
    }
}
