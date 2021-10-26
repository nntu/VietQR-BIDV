using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.IO;

namespace VietQR
{
    public class Config<T> where T : new()
    {
        private static DefaultContractResolver contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        };

        private const string DEFAULT_FILENAME = "settings.json";

        public void Save(string fileName = DEFAULT_FILENAME)
        {
            //  File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(this));

#pragma warning disable CS0618 // 'StringEnumConverter.CamelCaseText' is obsolete: 'StringEnumConverter.CamelCaseText is obsolete. Set StringEnumConverter.NamingStrategy with CamelCaseNamingStrategy instead.'
            var output = JsonConvert.SerializeObject(this, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });
#pragma warning restore CS0618 // 'StringEnumConverter.CamelCaseText' is obsolete: 'StringEnumConverter.CamelCaseText is obsolete. Set StringEnumConverter.NamingStrategy with CamelCaseNamingStrategy instead.'

            File.WriteAllText(fileName, output);
        }

        public static void Save(T pSettings, string fileName = DEFAULT_FILENAME)
        {
            // File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(pSettings));

#pragma warning disable CS0618 // 'StringEnumConverter.CamelCaseText' is obsolete: 'StringEnumConverter.CamelCaseText is obsolete. Set StringEnumConverter.NamingStrategy with CamelCaseNamingStrategy instead.'
            var output = JsonConvert.SerializeObject(pSettings, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });
#pragma warning restore CS0618 // 'StringEnumConverter.CamelCaseText' is obsolete: 'StringEnumConverter.CamelCaseText is obsolete. Set StringEnumConverter.NamingStrategy with CamelCaseNamingStrategy instead.'

            File.WriteAllText(fileName, output);
        }

        public static T Load(string fileName = DEFAULT_FILENAME)
        {
            var settings = new JsonSerializerSettings();
#pragma warning disable CS0618 // 'StringEnumConverter.CamelCaseText' is obsolete: 'StringEnumConverter.CamelCaseText is obsolete. Set StringEnumConverter.NamingStrategy with CamelCaseNamingStrategy instead.'
            settings.Converters.Add(new StringEnumConverter { NamingStrategy = new CamelCaseNamingStrategy() });
#pragma warning restore CS0618 // 'StringEnumConverter.CamelCaseText' is obsolete: 'StringEnumConverter.CamelCaseText is obsolete. Set StringEnumConverter.NamingStrategy with CamelCaseNamingStrategy instead.'
            var t = new T();
            if (File.Exists(fileName))
            {
                var input = File.ReadAllText(fileName);
                JsonConvert.PopulateObject(input, t, settings);
            }
            else
            {
                Save(t, fileName);
            }
            return t;
        }
    }
}