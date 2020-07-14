using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Parbad
    {
        public Gateways Gateways { get; set; }
    }
    public class Gateways
    {
        public IranKish IranKish { get; set; }
        public Mellat Mellat { get; set; }
        public Melli Melli { get; set; }
        public Parsian Parsian { get; set; }
        public Pasargad Pasargad { get; set; }
        public Saman Saman { get; set; }
        public ZarinPall ZarinPall { get; set; }
    }
    public class IranKish
    {
        public string MerchantId { get; set; }

    }
    public class Mellat
    {
        public long TerminalId { get; set; }
        public string MyUsername { get; set; }
        public string UserPassword { get; set; }

    }
    public class Melli
    {
        public string TerminalId { get; set; }
        public string MerchantId { get; set; }
        public string TerminalKey { get; set; }


    }
    public class Parsian
    {
        public string Pin { get; set; }

    }
    public class Pasargad
    {
        public string MerchantCode { get; set; }
        public string TerminalCode { get; set; }
        public string PrivateKey { get; set; }

    }
    public class Saman
    {
        public string MerchantId { get; set; }
        public string Password { get; set; }
    }
    public class ZarinPall
    {
        public bool IsSandbox { get; set; }
        public string MerchantId { get; set; }
        public string Name { get; set; }
    }
}
