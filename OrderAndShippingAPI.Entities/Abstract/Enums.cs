using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Entities.Abstract
{
    public class Enums
    {
        public enum EShippingStatu
        {
            Pending,
            Transit,
            Delivered,
            Canceled,
            Returned

        }

        public enum EResultStatu
        {
            Success=0,
            Error=1,
            Warning=2,
            Info=3

        }
    }
}
