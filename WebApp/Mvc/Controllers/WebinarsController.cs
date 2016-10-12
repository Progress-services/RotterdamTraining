using SitefinityWebApp.Mvc.Models;
using SitefinityWebApp.Mvc.ViewModels;
using System.ComponentModel;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Title = "Webinars Widget", Name = "WebinarsWidget", SectionName = "CustomMvcWidgets")]
    public class WebinarsController : Controller
    {
        private WebinarViewModel model;

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public WebinarViewModel Model
        {
            get
            {
                return this.model ?? (this.model = new WebinarViewModel());
            }
        }

        public ActionResult Index()
        {
            return View("Index", Model);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.Index().ExecuteResult(this.ControllerContext);
        }
    }
}