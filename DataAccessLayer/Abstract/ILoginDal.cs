using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ILoginDal: IRepositories<Admin>
    {
        Admin addAuthorizeAdmin(string userName, string UserPassword);
    }
}
