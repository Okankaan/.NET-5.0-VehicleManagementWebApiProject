using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMEntities.VMDtos.ReturnResultEntities.Abstract;

namespace VMEntities.VMDtos.ReturnResultEntities
{
    public class Result : IResult
    {
        public Result(bool success, string message) : this(success)

        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
