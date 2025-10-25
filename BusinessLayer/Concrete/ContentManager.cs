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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;
        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }
        public void ContentAdd(Content _Content)
        {
            _contentDal.Insert(_Content);
        }

        public void ContentUpdate(Content Content)
        {
            throw new NotImplementedException();
        }

        public void DelteContent(Content Content)
        {
            throw new NotImplementedException();
        }

        public Content GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetListByHeadingID()
        {
            return _contentDal.List();
        }

        public List<Content> GetListByHeadingID(int id)
        {
            return _contentDal.List(x => x.HeadingId == id); // burada çalışacak olan list ile yukarıdaki gelist çalışacak olan list genericrepositorydeki aynı listler değiller. Burada çalışacak olan list parametreye göre getiren list. istersen generic repo yu açıp bakablirisin 
        }

        public List<Content> GetListByHeadingWriter(int id)
        {
            return _contentDal.List(x => x.WriterId == id); // session kullanana kadar şimidlik 4 giriyoruz
        }
    }
}
