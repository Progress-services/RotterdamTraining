using SitefinityWebApp.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using SitefinityWebApp.Resources;

namespace SitefinityWebApp.Mvc.Controllers
{
    [Localization(typeof(BreakingNewsResources))]
    [ControllerToolboxItem(Title = "Breaking News", Name = "BreakingNews", SectionName = "CustomMvcWidgets")]
    public class BreakingNewsController : Controller
    {
        public string BreakingNewsMessage { get; set; }

        public string Title { get; set; }

        public string SelectedNewsItem { get; set; }

        // GET: BreakingNews
        public ActionResult Index()
        {
            BreakingNewsModel model = new BreakingNewsModel();
            model.Message = this.BreakingNewsMessage;

            return View(model);
        }
    }
}