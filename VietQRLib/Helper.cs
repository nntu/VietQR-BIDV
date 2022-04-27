using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VietQRLib
{
    public class Helper
    {

        private static banks json_banks;

        public static string addField(string currentString, string code, string value)
        {
            var newValue = currentString;
            if (newValue == String.Empty)
            {
                newValue = "";
            }
            newValue = newValue + code +   value.Length.ToString("D2")  + value;
            return newValue;
        }


        public static string generateMerchantInfo(string bankId, string accountNo, bool isAccount)
        {
            var merchantInfo = "";
            var receiverInfo = "";
            var serviceCode = getNapasServiceCode(isAccount);
            var binCode = "";
            try
            {
                binCode = getBIN(bankId);
            }
            catch (InvalidBankIdException e)
            {
                throw e;
            }
            receiverInfo = addField(receiverInfo, VietQRField.CONSUMER_INFO_CONSUMER_BIN, binCode);
            receiverInfo = addField(receiverInfo, VietQRField.CONSUMER_INFO_CONSUMER_MERCHANT, accountNo);

            merchantInfo = addField(merchantInfo, VietQRField.CONSUMER_INFO_GUID, "A000000727");
            merchantInfo = addField(merchantInfo, VietQRField.CONSUMER_INFO_CONSUMER, receiverInfo);
            merchantInfo = addField(merchantInfo, VietQRField.CONSUMER_INFO_SERVICE_CODE, serviceCode);

            return merchantInfo;
        }

        private static string getBIN(string bankId)
        {
            if (bankId == string.Empty)
            {
                throw new InvalidBankIdException();
            }

            var bank = loadDataBanks();
            var bin = bank.data.FirstOrDefault(c => c.code == bankId.ToUpper()).bin;
            if (bin == null)
            {
                return "";
            }
            else
            {
                return bin;
            }

        }

        public static string getNapasServiceCode(bool isCard)
        {
            if (isCard)
            {
                return Constants.NAPAS_247_BY_CARD;
            }
            else
            {
                return Constants.NAPAS_247_BY_ACCOUNT;
            }
        }
        public static banks loadDataBanks()
        {
            if (json_banks == null)
            {
                Assembly _assembly;           

                _assembly = Assembly.GetExecutingAssembly();
                string resourceName = _assembly.GetManifestResourceNames().Single(str => str.EndsWith("banks.json"));
                using (Stream stream = _assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string result = reader.ReadToEnd();
                    json_banks = JsonConvert.DeserializeObject<banks>(result);

                }
            }
            return json_banks;
        }

    }
}
