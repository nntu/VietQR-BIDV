using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeTran.viet_qr_generator
{
    public class banks
    {
        public string no_banks { get;set; }
        public List<databanks> data { get;set; }    
    }


    public class databanks
    {
         public string name { get;set; }    
            public string code  { get;set; }    
        public string bin { get;set; }  

        public string short_name { get;set; }
        public int? id { get; set; }
    }
}
