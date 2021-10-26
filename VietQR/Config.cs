using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietQR
{
    public class Config : Config<Config>
    {

        public bool IsProxy { get; set; }
        public string ProxyServer { get; set; }
        public string  proxyport { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        

    }


}
