using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMEntities.VMDtos.ReturnResultEntities.Abstract
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
