using SitefinityWebApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Title = "Breaking News", Name = "BreakingNews", SectionName = "CustomMvcWidgets")]
    public class BreakingNewsController : Controller
    {
        public string BreakingNewsMessage { get; set; }

        public object SelectedNewsItem { get; set; }

        // GET: BreakingNews
        public ActionResult Index()
        {
            BreakingNewsModel model = new BreakingNewsModel();
            model.Message = this.BreakingNewsMessage;

            return View(model);
        }
    }
}