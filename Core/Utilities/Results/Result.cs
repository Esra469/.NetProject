using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message):this(success)//iki parametre gönderen biri için this veriyoruz bu demek oluyor ki tmm sen çalış ama tek parametre olanı da çalıştır.
        {
          Message = message;//getter readonly dır. readonlyler constractorda set edilebilir.
          Success= success;

        }
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
