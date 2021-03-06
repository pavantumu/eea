﻿using EEAFormI9Portal.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEAFormI9Portal.Factory.IServices
{
    public interface IDocumentManagement
    {
        List<DocumentCurrent> GetDocumentDetails();
        List<DocumentCurrent> GetDocumentDetailsByFilter(string docFilter);
        List<DocumentStatu> GetDocumentStatusDetails();
    }
}
