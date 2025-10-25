using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Reppositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    //burası ICategoryService interfaceini implemente ediyor, yani içindeki metotları doldurmak zorunda. Bu doldurma işlemini ise DataAccessLayerıda bulunan interfacleri kullanakarak yapıyor

    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category _category)
        {
            //burada yapılacak ilgili valdasyon işlemleri controller tarafında yapılır
            _categoryDal.Insert(_category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public void DelteCategory(Category category)
        {
            _categoryDal.Delete(category);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.Get(x => x.CategoryId == id);  //burada Get methodu genericrepositoryden geliyor. Geliş zinciri şöyle: ICategoryDal ı burada kullandık. ICategoryDalın içi IRepsitoriesten geliyor. I repositoriesin içindeki methodlar GenericRepositorieste dolduruluyor. Böylece burada gelen Get methodu aslında Generic repositoriesten gelmiş oluyor ve biz bu yapıya newlwmw yapmadan yeni bağımlılıkları azaltarak ulaşabilmiş oluyoruz.
        }

        public List<Category> GetList()
        {
            return _categoryDal.List(); //burada gelen List methodu genericrepositoryden geliyor. Geliş zinciri şöyle: ICategoryDal ı burada kullandık. ICategoryDalın içi IRepsitoriesten geliyor. I repositoriesin içindeki methodlar GenericRepositorieste dolduruluyor. Böylece burada gelen list methodu aslında Generic repositoriesten gelmiş oluyor ve biz bu yapıya newlwmw yapmadan yeni bağımlılıkları azaltarak ulaşabilmiş oluyoruz.  
        }   

       
    }
}
