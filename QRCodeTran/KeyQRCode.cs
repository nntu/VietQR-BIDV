using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeTran
{
    public class KeyQRCode
    {
        public string so_tk { get; set; }

        public KeyQRCode(string sotk)
        {

            so_tk = sotk;

        }
        
        public string toString()
        {
            // 000201010210020210 
            // 03 06 970418 
            // 04 04 BIDV
            // 07 14 {acctno}
            // 08 {namelength} {custname}
            // 10037045802VN6304022F


            string result = "00020101021138570010A000000727012700069704180113{0}0208QRIBFTTA53037045802VN6304";
            ;                
            return string.Format(result, so_tk);

        }
    }
}
