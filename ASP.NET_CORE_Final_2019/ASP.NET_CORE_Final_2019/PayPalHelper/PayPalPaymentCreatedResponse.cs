using PayPal.v1.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_CORE_Final_2019.PayPalHelper
{
    public class PayPalPaymentCreatedResponse
    {
        public string id { get; set; }
        public string intent { get; set; }
        public string state { get; set; }
        public Payer payer { get; set; }
        public Transaction[] transactions { get; set; }
        public DateTime create_time { get; set; }
        public Link[] links { get; set; }

        public class Payer
        {
            public string payment_method { get; set; }
        }

        public class Transaction
        {
            public Amount amount { get; set; }
            public string itemList { get; set; }
            public object[] related_resources { get; set; }
        }

        public class Amount
        {
            public string total { get; set; }
            public string currency { get; set; }
        }
        public class ItemListt
        {
            public string test1 { get; set; }
            public string test2 { get; set; }
        }
        public class Link
        {
            public string href { get; set; }
            public string rel { get; set; }
            public string method { get; set; }
        }
    }
}
