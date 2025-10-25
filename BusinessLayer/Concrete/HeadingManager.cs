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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal ;
        }

        public void DelteHeading(Heading _heading)
        {
            //_heading.HeadimgStatus = false ; kodumuzu önceden böyle yazmıştık ve doğru olmadığı için böyle bırakmadık. onun yerine vu işi hedaing kontrollerda yaptık 
            _headingDal.Update(_heading);
        }

        public Heading GetByID(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);
        }

        public List<Heading> GetList()
        {
            return _headingDal.List();
        }

        public List<Heading> GetListByWriter(int id)
        {
           return _headingDal.List(x => x.WriterId == id);
        }

        public void HeadingAdd(Heading _heading)
        {
             _headingDal.Insert(_heading);
        }

        public void HeadingUpdate(Heading _heading)
        {
            _headingDal.Update(_heading);
        }
    }
}
