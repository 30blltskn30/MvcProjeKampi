using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetListByWriter(int id );
        void HeadingAdd(Heading _heading);
        Heading GetByID(int id);

        void DelteHeading(Heading _heading);

        void HeadingUpdate(Heading _heading);
    }
}
