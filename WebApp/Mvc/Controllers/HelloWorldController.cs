using SitefinityWebApp.Mvc.Models;
using System;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Title = "Hello World", Name = "HelloWord", SectionName = "CustomMvcWidgets")]
    public class HelloWorldController : Controller
    {
        public string HelloWorldMessage { get; set; }

        public string TeaserImageUrl { get; set; }

        public ActionResult Index()
        {
            HelloWorldModel model = new HelloWorldModel();
            model.Message = this.HelloWorldMessage;
            model.TeaserImageUrl = this.TeaserImageUrl;

            return View(model);
        }

        public ActionResult RandomNumber()
        {
            HelloWorldModel model = new HelloWorldModel();
            model.RandNumber = new Random().Next(0, 100);
            return View("Random", model);
        }
    }
}