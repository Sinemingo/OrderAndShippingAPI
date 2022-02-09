using OrderAndShippingAPI.Entities.Abstract;
using OrderAndShippingAPI.Entities.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Entities.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(Enums.EResultStatu resultSatatus,T data)
        {
            ResultStatus = resultSatatus;
            Data = data;
        }
        public DataResult(Enums.EResultStatu resultSatatus, T data, string message)
        {
            ResultStatus = resultSatatus;
            Message = message;
            Data = data;
        }
        public DataResult(Enums.EResultStatu resultSatatus, T data, string message, Exception ex)
        {
            ResultStatus = resultSatatus;
            Message = message;
            Ex = ex;
            Data = data;
        }
        public T Data { get; }

        public Enums.EResultStatu ResultStatus { get; }

        public string Message { get; }

        public Exception Ex { get; }
    }
}
