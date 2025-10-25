using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public  interface IRepositories<T>
    {
        // bu şekilde kullanmamız bütün interacler için bir değişiklik yapılacağı zaman merkezcil bir kontrol sağlar,  fakat sadece bellirli bir interfacede yapılacak değişiklik için Dal ile bite interfaceleri tanımladık
            List<T> List();
            void Insert(T p);
            T Get(Expression<Func<T, bool>> filter);//tek bir değer döndürecek. Örneğin Id si 5 olan yazar
            void Update(T p);
            void Delete(T p);

            List<T> List(Expression<Func<T,bool>> filter);//şartlı listeleme için kullanılır ve birden fazle değer döndürü. Örenğin Adı ahmet olan yazarlar
    }
   }
