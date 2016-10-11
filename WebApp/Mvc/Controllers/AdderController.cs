using SitefinityWebApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "AdderWidget", Title = "Adder controler", SectionName = "CustomMvcWidgets")]
    public class AdderController : Controller
    {
        private AdderModel model;

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public AdderModel Model
        {
            get
            {
                return this.model ?? (this.model = new AdderModel());
            }
        }


        public ActionResult Index()
        {
            return View("Index", this.Model);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.Index().ExecuteResult(this.ControllerContext);
        }
    }
}