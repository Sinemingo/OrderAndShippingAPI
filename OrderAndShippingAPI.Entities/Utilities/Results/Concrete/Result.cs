using OrderAndShippingAPI.Entities.Abstract;
using OrderAndShippingAPI.Entities.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Entities.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(Enums.EResultStatu resultSatatus)
        {
            ResultStatus = resultSatatus;
        }
        public Result(Enums.EResultStatu resultSatatus, string message)
        {
            ResultStatus = resultSatatus;
            Message = message;
        }
        public Result(Enums.EResultStatu resultSatatus, string message,Exception ex)
        {
            ResultStatus = resultSatatus;
            Message = message;
            Ex = ex;
        }
        public Enums.EResultStatu ResultStatus { get; }

        public string Message { get; }

        public Exception Ex { get; }
    }
}
