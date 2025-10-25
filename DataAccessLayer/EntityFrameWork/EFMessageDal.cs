using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Reppositories;
using EntityLayer.Concrete;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DataAccessLayer.EntityFrameWork
{
    public class EFMessageDal : GenericRepository<Message>, IMessageDal
    {
        
        
        
    }
}
