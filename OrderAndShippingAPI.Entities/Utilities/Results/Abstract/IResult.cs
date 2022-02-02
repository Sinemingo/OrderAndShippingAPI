using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderAndShippingAPI.Entities.Abstract.Enums;

namespace OrderAndShippingAPI.Entities.Utilities.Results.Abstract
{
    public interface IResult
    {
        public EResultStatu ResultStatus { get;}
        public string Message { get;}
        public Exception Ex { get; }
    }
}
