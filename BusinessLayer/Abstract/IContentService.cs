using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface IContentService
    {
        List<Content> GetListByHeadingID();
        List<Content> GetListByHeadingWriter(int id);//yazara çok içerik listeler
        List<Content> GetListByHeadingID(int id);//başlığa göre çok içerik listeler
        
        void ContentAdd(Content _Content);
        Content GetByID(int id); //id ye göre tek içerik getirir

        void DelteContent(Content Content);

        void ContentUpdate(Content Content);
    }
}
