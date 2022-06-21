using System;
using System.Text;

namespace QRNapasLib
{
    public static class Generator
    {
        //// Bank ID
        //public static string bankId { get; set; }
        ////  Account No
        //public static string accountNo { get; set; }
        //// Amount to transfer
        //public static int amount { get; set; }
        // Ref
        public static string info = "";

        //// Return text or image in base64

        //// Data path
        public static string data;

        // Bank tranfer by card id
        public static bool isCard = false;

        // Labels
        public static string labels;

        public static string Generator_VietQR(string bankId, string accountNo, int amount, string info)
        {
            var stringToGenerate = "";
            var paymentType = "11";
            var consumerInfo = Helper.generateMerchantInfo(bankId, accountNo, isCard);
            // Add header
            stringToGenerate = Helper.addField(stringToGenerate, VietQRField.VERSION, "01");
            if (info != "")
            {
                paymentType = "12";
            }
            // Payment type. 11 if permantly. 12 otherwise
            stringToGenerate = Helper.addField(stringToGenerate, VietQRField.INITIATION_METHOD, paymentType);
            // Add consumer info
            stringToGenerate = Helper.addField(stringToGenerate, VietQRField.CONSUMER_INFO, consumerInfo);
            // Add currency
            stringToGenerate = Helper.addField(stringToGenerate, VietQRField.CURRENCY_CODE, "704");
            if (amount != 0)
            {
                // Add amount
                stringToGenerate = Helper.addField(stringToGenerate, VietQRField.TRANSACTION_AMOUNT, amount.ToString());
            }
            stringToGenerate = Helper.addField(stringToGenerate, VietQRField.COUNTRY_CODE, "VN");
            if (info != "")
            {
                var refc = Helper.addField("", VietQRField.ADDITION_REF, info);
                stringToGenerate = Helper.addField(stringToGenerate, VietQRField.ADDITION, refc);
            }
            byte[] bytes = Encoding.ASCII.GetBytes(stringToGenerate + VietQRField.CRC + "04");

            CRCTool foo = new CRCTool();
            var a = foo.CalcCRCITT(bytes);
            string hexOutput = String.Format("{0:X}", a);
            data = Helper.addField(stringToGenerate, VietQRField.CRC, hexOutput);
            return data;
        }

        public static string Generator_VietQR(string bankId, string accountNo)
        {
            var stringToGenerate = "";
            var paymentType = "11";
            var consumerInfo = Helper.generateMerchantInfo(bankId, accountNo, isCard);
            // Add header
            stringToGenerate = Helper.addField(stringToGenerate, VietQRField.VERSION, "01");
            if (info != "")
            {
                paymentType = "12";
            }
            // Payment type. 11 if permantly. 12 otherwise
            stringToGenerate = Helper.addField(stringToGenerate, VietQRField.INITIATION_METHOD, paymentType);
            // Add consumer info
            stringToGenerate = Helper.addField(stringToGenerate, VietQRField.CONSUMER_INFO, consumerInfo);
            // Add currency
            stringToGenerate = Helper.addField(stringToGenerate, VietQRField.CURRENCY_CODE, "704");

            stringToGenerate = Helper.addField(stringToGenerate, VietQRField.COUNTRY_CODE, "VN");

            string chuoima = stringToGenerate + VietQRField.CRC + "04";

            byte[] bytes = Encoding.ASCII.GetBytes(chuoima);

            CRCTool foo = new CRCTool();
            var a = foo.CalcCRCITT(bytes);
            string hexOutput = String.Format("{0:X}",(int) a);
            if (hexOutput.Length == 3) hexOutput = "0" + hexOutput;
            data = Helper.addField(stringToGenerate, VietQRField.CRC, hexOutput);
            return data;
        }
    }
}