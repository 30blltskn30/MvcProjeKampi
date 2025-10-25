using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    //bu ve CategoryRepository yapılarını bı işin nasıl olmaması gerektiğini anlaatmak için yaptık 
    public interface ICategoryDal:IRepositories<Category>
    {
        //Crud
        //Type Name()
        
        //List<Category> List();

        //void Insert(Category p);

        //void Update(Category p);

        //void Delete(Category p);
        //Category Get(Func<object, bool> value);
    }
}
