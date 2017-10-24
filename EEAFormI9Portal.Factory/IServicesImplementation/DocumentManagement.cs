using EEAFormI9Portal.Factory.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EEAFormI9Portal.EF;

namespace EEAFormI9Portal.Factory.IServicesImplementation
{
    public class DocumentManagement : IDocumentManagement
    {
        private readonly EEAFORMI9Entities db = new EEAFORMI9Entities();

        public List<DocumentCurrent> GetDocumentDetails()
        {
            //var doc = new DocumentCurrent();
            var doc = db.DocumentCurrents.ToList();
            return doc;
        }
    }
}
