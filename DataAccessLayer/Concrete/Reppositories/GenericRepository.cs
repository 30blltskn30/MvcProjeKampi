using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DataAccessLayer.Concrete.Reppositories
{
    //Repository design patternı kulanarak generic bir repository oluşturuyoruz ve her bir entity için tek tek repolar oluşturmuyoruz

    public class GenericRepository<T> : IRepositories<T> where T : class
    {
        Context Context = new Context();
        DbSet<T> _object; //_object T değerine karşılık gelen sınıfı temsil eder



        public GenericRepository()
        {
            _object = Context.Set<T>(); //T değerine karşılık gelen sınıfı nasıl bulacağımızı ise constructer ile belirliyoruz
        }


        public void Delete(T p)
        {
            var deletedEntity = Context.Entry(p);//gönderilen p nesnesinin context içindeki karşılığını bulur
            deletedEntity.State = EntityState.Deleted;//o nesnenin durumunu deleted olarak işaretler
            // _object.Remove(p);
            Context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);//bir dizide veya listede sadece bir tane değer döndürmek için kullanılan LinQ methodur
        }

        public void Insert(T p)
        {
            var addedEntity = Context.Entry(p);//gönderilen p nesnesinin context içindeki karşılığını bulur
            addedEntity.State = EntityState.Added;//o nesnenin durumunu added olarak işaretler
            //_object.Add(p); //Entity state eklemeden önce bu şekilde ekleme yapıyoduk
            Context.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();

        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updatedEntity = Context.Entry(p);//gönderilen p nesnesinin context içindeki karşılığını bulur
            updatedEntity.State = EntityState.Modified;//o nesnenin durumunu modified olarak işaretler

            Context.SaveChanges();
        }
    }
}
