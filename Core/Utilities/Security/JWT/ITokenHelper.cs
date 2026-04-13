using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //kullanıcı clientten giriş yaptı api ye gönderildi. ordan her Users için veritabanına bakıldı. 
        AccessToken CreateToken(User user,List<OperationClaim> operationClaims);
    }
}
