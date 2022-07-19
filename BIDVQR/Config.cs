using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIDVQR
{
    public class Config : Config<Config>
    {
        public string ChiNhanh { get; set; }

        public string CanBoPhuTrach { get; set; }
        
        public int template { get; set; }

    }


}
