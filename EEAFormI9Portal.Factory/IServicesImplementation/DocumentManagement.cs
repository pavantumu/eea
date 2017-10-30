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
            if(doc.Count > 0)
            {
                foreach(DocumentCurrent item in doc)
                {
                    var user = db.AspNetUsers.SingleOrDefault(x => x.Id == item.UserId);

                }
                
            }
            
            return doc;
        }

        public List<DocumentCurrent> GetDocumentDetailsByFilter(string docFilter)
        {
            //var doc = db.DocumentCurrents.ToList();
            var singleDoc = new DocumentCurrent();
            var doc = new List<DocumentCurrent>();
            var allDoc = db.DocumentCurrents.ToList();
            if (allDoc.Count > 0)
            {
                foreach (DocumentCurrent item in doc)
                {
                    singleDoc = db.DocumentCurrents.SingleOrDefault(x => x.DocumentStatu.Status == docFilter);
                    doc.Add(singleDoc);
                }
                

            }

            return doc;
        }

        public List<DocumentStatu> GetDocumentStatusDetails()
        {
            var doc = new List<DocumentStatu>();
            doc = db.DocumentStatus.ToList();

            return doc;
        }
    }
}
