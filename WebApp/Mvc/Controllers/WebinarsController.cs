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
        private WebinarModel model;

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public WebinarModel Model
        {
            get
            {
                return this.model ?? (this.model = new WebinarModel());
            }
        }

        public string SelectedItem { get; set; }

        public ActionResult Index()
        {
            return View("Index", this.Model.Webinars);
        }

        protected override void HandleUnknownAction(string actionName)
        {
            this.Index().ExecuteResult(this.ControllerContext);
        }
    }
}