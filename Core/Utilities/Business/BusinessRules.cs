using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    //bu bir araç yani utilities sonuç olarak classın burada boş kalması çok dert değil. 
    public class BusinessRules
    {
        //params istediğin kadar parametre koy demek parametre olarak gönderdiğimiz iş kuralını başarısız olanı businesse bu logic hatalı diyoruz.
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
