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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void AboutAdd(About _About)
        {
            _aboutDal.Insert(_About);
        }

        public void AboutUpdate(About About)
        {
            _aboutDal.Update(About);
        }

        public void DelteAbout(About About)
        {
            _aboutDal.Delete(About);
        }

        public About GetByID(int id)
        {
            return _aboutDal.Get(x=>x.AboutId==id);
        }

        public List<About> GetList()
        {
            return _aboutDal.List();
        }
    }
}
