using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Reppositories;
using EntityLayer.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFrameWork
{
    public class EFLoginDal : GenericRepository<Admin>, ILoginDal
    {
        Context _context = new Context();

        public EFLoginDal(Context context)
        {
            _context = context;
        }

        public Admin addAuthorizeAdmin(string userName, string UserPassword)
        {
           return _context.Admins.FirstOrDefault(x => x.AdminUserName == userName && x.AdminPassword == UserPassword);
        }
    }
}
