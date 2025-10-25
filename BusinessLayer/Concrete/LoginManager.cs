using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LoginManager : ILoginService
    {
        ILoginDal _loginDal;

        public LoginManager(ILoginDal loginDal)
        {
            _loginDal = loginDal;
        }

        public Admin AddAdmin(string UserName, string UserPAssword)
        {
            var adminUser = _loginDal.addAuthorizeAdmin(UserName, UserPAssword);

            if (adminUser != null)
            {
                // Başarılı giriş
                return adminUser;
            }

            // Başarısız
            return null;
        }
    }
}
