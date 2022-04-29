using System.Collections.Generic;

namespace VietQRLib
{
    public class banks
    {
        public string no_banks { get; set; }
        public List<databanks> data { get; set; }
    }

    public class databanks
    {
        public string name { get; set; }
        public string code { get; set; }
        public string bin { get; set; }
        public string short_name { get; set; }
        public int? id { get; set; }
        public bool isTransfer { get; set; }
    }
}