using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message):base(true,message) // base demek successresult yanında yazan result demek oluyor.
        {

        }
        public SuccessResult() : base(true)
        {

        }
    }
}
