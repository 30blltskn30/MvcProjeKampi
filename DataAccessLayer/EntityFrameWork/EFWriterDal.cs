using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Reppositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFrameWork
{
    public class EFWriterDal:GenericRepository<Writer>, IWriterDal
    {
    }
}
