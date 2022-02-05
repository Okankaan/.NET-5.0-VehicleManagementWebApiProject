using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMEntities.VMDtos.ReturnResultEntities.Abstract;

namespace VMEntities.VMDtos.ReturnResultEntities
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
