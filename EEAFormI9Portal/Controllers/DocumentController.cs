using EEAFormI9Portal.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using EEAFormI9Portal.Models;

namespace EEAFormI9Portal.Controllers
{
    public class DocumentController : BaseController
    {
        // GET: Document
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetDocumentDetails()
        {
            var doc = new List<DocumentCurrent>();
            doc = _IDocumentManagement.GetDocumentDetails();
            var e = Mapper.Map<List<ViewDocument>>(doc);

            return Json(e, JsonRequestBehavior.AllowGet);
        }
    }
}