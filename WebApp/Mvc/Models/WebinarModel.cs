using SitefinityWebApp.Mvc.ViewModels;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using Telerik.Sitefinity.Model;
using Telerik.Sitefinity.DynamicModules;
using Telerik.Sitefinity.Utilities.TypeConverters;
using Telerik.Sitefinity.GenericContent.Model;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace SitefinityWebApp.Mvc.Models
{
    public class WebinarModel
    {
        public string WebinarItems
        {
            get
            {
                if (string.IsNullOrEmpty(this.webinarItems))
                    this.webinarItems = JsonConvert.SerializeObject(this.Webinars);

                return this.webinarItems;
            }
            set
            {
                this.webinarItems = value;
            }
        }

        [Browsable(false)]
        public List<WebinarViewModel> Webinars
        {
            get
            {
                if (this.webinars == null)
                {
                    if (!string.IsNullOrEmpty(this.webinarItems))
                    {
                        this.webinars = JsonConvert.DeserializeObject<List<WebinarViewModel>>(this.webinarItems);
                    }
                    else
                    {
                        this.webinars = new List<WebinarViewModel>{
                            new WebinarViewModel(),
                            new WebinarViewModel()
                        };
                    }
                }

                return this.webinars;
            }
        }

        public IEnumerable<WebinarViewModel> GetContentList()
        {
            Type webinarType = TypeResolutionService.ResolveType("Telerik.Sitefinity.DynamicTypes.Model.Webinars.Webinar");

            var dynamicModuleManager = DynamicModuleManager.GetManager();

            var webinars = dynamicModuleManager.GetDataItems(webinarType).Where(d => d.Status == ContentLifecycleStatus.Live)
                .Select(w => new WebinarViewModel()
                {
                    Title = w.GetValue<string>("Title"),
                    Description = w.GetString("Description").Value,
                    StartDate = w.GetValue<DateTime?>("Start") ?? DateTime.UtcNow,
                    EndDate = w.GetValue<DateTime?>("End") ?? DateTime.UtcNow
                });


            return webinars.AsEnumerable();
        }

        private List<WebinarViewModel> webinars;
        private string webinarItems;
    }
}