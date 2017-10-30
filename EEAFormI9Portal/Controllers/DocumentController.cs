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

        [HttpGet]
        public JsonResult GetDocumentDetailsByFilter(string filter)
        {
            var doc = new List<DocumentCurrent>();
            doc = _IDocumentManagement.GetDocumentDetailsByFilter(filter);
            var result = Mapper.Map<List<ViewDocument>>(doc);

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ViewDocumentStatusDetails()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetDocumentStatusDetails()
        {
            var doc = new List<DocumentStatu>();
            doc = _IDocumentManagement.GetDocumentStatusDetails();
            var result = Mapper.Map<List<ViewDocumentStatus>>(doc);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}