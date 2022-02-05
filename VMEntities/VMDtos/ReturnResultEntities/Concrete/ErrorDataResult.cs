using System;
using System.Collections.Generic;
using System.Text;
using VMEntities.VMDtos.ReturnResultEntities.Abstract;

namespace VMEntities.VMDtos.ReturnResultEntities
{
    public class ErrorDataResult<T> : DataResult<T>, IDataResult<T>
    {

        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        public ErrorDataResult(T data) : base(data, false)
        {

        }

        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        public ErrorDataResult() : base(default, true)
        {

        }
    }
}
